namespace StudentAttendance.Core.Domains.Tokens.Services;

public interface ITokenService
{
    Task<TokenModel> Login(string login, string password);
    Task<TokenModel> GetTokenByRefreshToken(string refreshToken);
}