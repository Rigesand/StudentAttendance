using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.RefreshTokens;
using StudentAttendance.Core.Domains.RefreshTokens.Repositories;

namespace StudentAttendance.Data.Entities.RefreshTokens.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IMapper _mapper;
    private readonly StudentAttendanceDbContext _context;

    public RefreshTokenRepository(IMapper mapper, StudentAttendanceDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    private async Task AddRefreshToken(RefreshToken refreshToken)
    {
        var refreshTokenDb = _mapper.Map<RefreshToken, RefreshTokenDbModel>(refreshToken);
        await _context.RefreshTokens.AddAsync(refreshTokenDb);
    }

    public async Task<RefreshToken> IsExists(string refreshToken)
    {
        var refreshTokenDbModel = await _context.RefreshTokens.FirstOrDefaultAsync(it => it.Token == refreshToken);
        if (refreshTokenDbModel == null)
        {
            return null;
        }

        var refreshTokenCore = _mapper.Map<RefreshTokenDbModel, RefreshToken>(refreshTokenDbModel);
        return refreshTokenCore;
    }

    public async Task GenerateToken(RefreshToken refreshToken)
    {
        var refreshTokenDb = await _context.RefreshTokens
            .FirstOrDefaultAsync(it => it.UserId == refreshToken.UserId);

        if (refreshTokenDb == null)
        {
            await AddRefreshToken(refreshToken);
            return;
        }

        refreshTokenDb.Token = refreshToken.Token;
        refreshTokenDb.AddedDate = refreshToken.AddedDate;
        refreshTokenDb.ExpiryDate = refreshToken.ExpiryDate;

        _context.RefreshTokens.Update(refreshTokenDb);
    }
}