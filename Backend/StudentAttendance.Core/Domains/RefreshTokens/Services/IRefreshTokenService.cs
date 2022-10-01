namespace StudentAttendance.Core.Domains.RefreshTokens.Services;

public interface IRefreshTokenService
{
    public Task<RefreshToken> IsExists(string refreshToken);
    public Task<int> Update(RefreshToken refreshToken);
}