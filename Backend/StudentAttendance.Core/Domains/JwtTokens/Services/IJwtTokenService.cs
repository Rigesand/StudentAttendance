using Microsoft.IdentityModel.Tokens;
using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Core.Domains.JwtTokens.Services;

public interface IJwtTokenService
{
    public Task<JwtTokens> GenerateJwtToken(User? user, string secret);

    public Task<JwtTokens> VerifyAndGenerateToken(JwtTokens tokens, TokenValidationParameters validationParameters,
        string secret);
}