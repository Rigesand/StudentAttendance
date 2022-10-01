using StudentAttendance.Core.Domains.RefreshTokens.Repositories;

namespace StudentAttendance.Core.Domains.RefreshTokens.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<int> AddRefreshToken(RefreshToken refreshToken)
    {
        return await _refreshTokenRepository.GenerateToken(refreshToken);
    }

    public async Task<RefreshToken> IsExists(string refreshToken)
    {
        return await _refreshTokenRepository.IsExists(refreshToken);
    }

    public async Task<int> Update(RefreshToken refreshToken)
    {
        return await _refreshTokenRepository.GenerateToken(refreshToken);
    }
}