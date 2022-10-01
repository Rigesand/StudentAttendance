using Microsoft.AspNetCore.Identity;
using StudentAttendance.Data.Entities.RefreshTokens;

namespace StudentAttendance.Data.Entities.Users;

public class UserDbModel : IdentityUser
{
    public RefreshTokenDbModel? RefreshToken { get; set; }
}