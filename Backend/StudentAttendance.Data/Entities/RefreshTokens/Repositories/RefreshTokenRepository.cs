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
        await _context.SaveChangesAsync();
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

    public async Task<int> GenerateToken(RefreshToken refreshToken)
    {
        var result = await _context.RefreshTokens.FirstOrDefaultAsync(it => it.UserId == refreshToken.UserId);
        if (result == null)
        {
            await AddRefreshToken(refreshToken);
            return 0;
        }

        result.Token = refreshToken.Token;
        result.AddedDate = refreshToken.AddedDate;
        result.ExpiryDate = refreshToken.ExpiryDate;

        await _context.SaveChangesAsync();
        return 0;
    }
}