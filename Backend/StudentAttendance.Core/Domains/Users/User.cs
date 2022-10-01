using Microsoft.AspNetCore.Identity;
using StudentAttendance.Core.Domains.RefreshTokens;

namespace StudentAttendance.Core.Domains.Users;

public class User : IdentityUser
{
    public RefreshToken? RefreshToken { get; set; }
}