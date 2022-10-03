﻿namespace StudentAttendance.Core.Domains.RefreshTokens.Repositories;

public interface IRefreshTokenRepository
{
    public Task<RefreshToken> IsExists(string refreshToken);
    public Task GenerateToken(RefreshToken refreshToken);
}