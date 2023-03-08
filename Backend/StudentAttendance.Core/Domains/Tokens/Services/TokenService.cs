using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentAttendance.Core.Configuration;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Core.Domains.Tokens.Services;

public class TokenService : ITokenService
{
    private readonly AuthConfig _config;
    private readonly IUserService _userService;

    public TokenService(IOptions<AuthConfig> config, IUserService userService)
    {
        _userService = userService;
        _config = config.Value;
    }

    private TokenModel GenerateTokens(User user)
    {
        var dtNow = DateTime.Now;
        var jwt = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            notBefore: dtNow,
            claims: new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim("id", user.Id.ToString()),
                new Claim("role", user.Role)
            },
            expires: DateTime.Now.AddMinutes(_config.LifeTime),
            signingCredentials: new SigningCredentials(_config.SymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        var refresh = new JwtSecurityToken(
            notBefore: dtNow,
            claims: new[]
            {
                new Claim("id", user.Id.ToString())
            },
            expires: DateTime.Now.AddHours(_config.LifeTime),
            signingCredentials: new SigningCredentials(_config.SymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedRefresh = new JwtSecurityTokenHandler().WriteToken(refresh);

        var tokens = new TokenModel
        {
            AccessToken = encodedJwt,
            RefreshToken = encodedRefresh
        };
        return tokens;
    }

    public async Task<TokenModel> Login(string login, string password)
    {
        var user = await _userService.GetUserByCredential(login, password);
        return GenerateTokens(user);
    }

    public async Task<TokenModel> GetTokenByRefreshToken(string refreshToken)
    {
        var validParams = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = _config.SymmetricSecurityKey()
        };

        var principal = new JwtSecurityTokenHandler().ValidateToken(refreshToken, validParams, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtToken
            || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("invalid token");
        }

        if (principal.Claims.FirstOrDefault(x => x.Type == "id")?.Value is String userIdString
            && Guid.TryParse(userIdString, out var userId))
        {
            var user = await _userService.GetUserById(userId);
            return GenerateTokens(user);
        }

        throw new SecurityTokenException("invalid token");
    }
}