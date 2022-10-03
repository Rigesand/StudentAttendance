using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentAttendance.Core.Domains.RefreshTokens;
using StudentAttendance.Core.Domains.RefreshTokens.Services;
using StudentAttendance.Core.Domains.Roles.Services;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Core.Domains.JwtTokens.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _secret;

    public JwtTokenService(
        IRefreshTokenService refreshTokenService,
        IUserService userService,
        IConfiguration configuration,
        IRoleService roleService, IUnitOfWork unitOfWork)
    {
        _refreshTokenService = refreshTokenService;
        _userService = userService;
        _roleService = roleService;
        _unitOfWork = unitOfWork;
        _secret = configuration["SecretSettings:Secret"];
    }

    public async Task<JwtTokens> GenerateJwtToken(User? user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        var role = await _roleService.GetRole(user);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user!.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role.Name)
            }),
            Expires = DateTime.UtcNow.AddMinutes(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        var newRefreshToken = new RefreshToken
        {
            JwtId = token.Id,
            IsUsed = false,
            IsRevorked = false,
            UserId = user.Id,
            AddedDate = DateTimeOffset.UtcNow,
            ExpiryDate = DateTimeOffset.UtcNow.AddMonths(6),
            Token = RandomString(35) + Guid.NewGuid()
        };

        await _refreshTokenService.SaveToken(newRefreshToken);
        await _unitOfWork.SaveChanges();
        return new JwtTokens
        {
            Token = jwtToken,
            RefreshToken = newRefreshToken.Token,
            Success = true,
            Errors = null
        };
    }

    public async Task<JwtTokens> VerifyAndGenerateToken(
        JwtTokens jwtTokens,
        TokenValidationParameters tokenValidationParams)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var tokenInVerification =
                jwtTokenHandler.ValidateToken(jwtTokens.Token, tokenValidationParams, out var validatedToken);

            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase);
                if (result == false)
                {
                    return null;
                }
            }

            var utcExpiryDate = long.Parse(tokenInVerification
                .Claims.FirstOrDefault(it => it.Type == JwtRegisteredClaimNames.Exp)!.Value);

            var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);

            if (expiryDate > DateTime.UtcNow)
            {
                return new JwtTokens
                {
                    Errors = new List<string>
                    {
                        "Token has not yet expired"
                    },
                    Success = false
                };
            }

            var storedToken = await _refreshTokenService.IsExists(jwtTokens.RefreshToken!);

            if (storedToken == null)
            {
                return new JwtTokens
                {
                    Errors = new List<string>
                    {
                        "Token does not exist"
                    },
                    Success = false
                };
            }

            if (storedToken.IsUsed)
            {
                return new JwtTokens
                {
                    Errors = new List<string>
                    {
                        "Token has been used"
                    },
                    Success = false
                };
            }

            if (storedToken.IsRevorked)
            {
                return new JwtTokens
                {
                    Errors = new List<string>
                    {
                        "Token has been revoked"
                    },
                    Success = false
                };
            }

            var jti = tokenInVerification.Claims.FirstOrDefault(it => it.Type == JwtRegisteredClaimNames.Jti)!.Value;

            if (storedToken.JwtId != jti)
            {
                return new JwtTokens
                {
                    Errors = new List<string>
                    {
                        "Token doesn't match"
                    },
                    Success = false
                };
            }

            storedToken.IsUsed = true;
            await _refreshTokenService.SaveToken(storedToken);

            var dbUser = await _userService.FindByIdAsync(storedToken.UserId!);

            var tokens = await GenerateJwtToken(dbUser);

            await _unitOfWork.SaveChanges();

            return new JwtTokens
            {
                Success = true,
                Token = tokens.Token,
                RefreshToken = tokens.RefreshToken
            };
        }
        catch (System.Exception ex)
        {
            return null;
        }
    }

    private DateTimeOffset UnixTimeStampToDateTime(long unixTimeStamp)
    {
        var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTimeVal = dateTimeVal.AddMinutes(unixTimeStamp).ToLocalTime();
        return dateTimeVal;
    }

    private string RandomString(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(x => x[random.Next(x.Length)]).ToArray());
    }
}