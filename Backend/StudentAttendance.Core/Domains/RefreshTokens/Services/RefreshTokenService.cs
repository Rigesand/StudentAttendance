using StudentAttendance.Core.Domains.RefreshTokens.Repositories;

namespace StudentAttendance.Core.Domains.RefreshTokens.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RefreshToken> IsExists(string refreshToken)
    {
        var token = await _refreshTokenRepository.IsExists(refreshToken);
        return token;
    }

    public async Task SaveToken(RefreshToken refreshToken)
    {
        await _refreshTokenRepository.GenerateToken(refreshToken);
        await _unitOfWork.SaveChanges();
    }
}