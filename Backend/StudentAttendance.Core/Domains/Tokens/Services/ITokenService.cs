namespace StudentAttendance.Core.Domains.Tokens.Services;

public interface ITokenService
{
    public Task<TokenModel> Login(string login, string password);
    public Task<TokenModel> GetTokenByRefreshToken(string refreshToken);
}