using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentAttendance.Core.Configuration;
using StudentAttendance.Core.Domains.Mail.Services;
using StudentAttendance.Core.Domains.Roles;
using StudentAttendance.Core.Domains.Roles.Repositories;
using StudentAttendance.Core.Domains.Tokens;
using StudentAttendance.Core.Domains.Tokens.Services;
using StudentAttendance.Core.Domains.Users.Repositories;
using StudentAttendance.Core.Exceptions;

namespace StudentAttendance.Core.Domains.Users.Services;

public class UserService : IUserService, ITokenService
{
    private readonly IUserRepository _userRepository;
    private readonly IMailService _mailService;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AuthConfig _config;

    public UserService(
        IUserRepository userRepository,
        IMailService mailService,
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork,
        IOptions<AuthConfig> config)
    {
        _userRepository = userRepository;
        _mailService = mailService;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _config = config.Value;
    }

    private string RandomString(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(x => x[random.Next(x.Length)]).ToArray());
    }

    private async Task<User> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null)
            throw new UserException("User not found");
        return user;
    }

    private async Task<User> GetUserByCredential(string login, string password)
    {
        var user = await _userRepository.FindByEmailAsync(login);
        if (user == null)
            throw new UserException("User not found");
        if (!HashService.Verify(password, user.PasswordHash!))
            throw new Exception("Password is incorrect");
        return user;
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
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email!),
                new Claim("id", user.Id.ToString())
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

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _userRepository.FindByEmailAsync(email);
    }

    public async Task<User> CreateAndSendMailAsync(User newUser, string role)
    {
        var password = RandomString(35);
        newUser.PasswordHash = HashService.GetHash(password);
        var existedRole = await _roleRepository.FindByNameAsync(role);
        if (existedRole == null)
        {
            await _roleRepository.CreateAsync(new Role(role));
            await _unitOfWork.SaveChanges();
        }

        var user = await _userRepository.CreateAsync(newUser, role);
        await _unitOfWork.SaveChanges();
        await _mailService.Send(user, password);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<bool> Delete(User user)
    {
        var isTrue = await _userRepository.Delete(user);
        if (!isTrue)
        {
            return false;
        }

        await _unitOfWork.SaveChanges();
        return true;
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await GetUserById(id);
        return user;
    }

    public async Task<TokenModel> Login(string login, string password)
    {
        var user = await GetUserByCredential(login, password);
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
            var user = await GetUserById(userId);
            return GenerateTokens(user);
        }

        throw new SecurityTokenException("invalid token");
    }
}