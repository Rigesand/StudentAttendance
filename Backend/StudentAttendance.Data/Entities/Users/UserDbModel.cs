using Microsoft.AspNetCore.Identity;
using StudentAttendance.Data.Entities.RefreshTokens;
using StudentAttendance.Data.Entities.Roles;

namespace StudentAttendance.Data.Entities.Users;

public class UserDbModel : IdentityUser
{
    public RefreshTokenDbModel? RefreshToken { get; set; }
    public RoleDbModel? Role { get; set; }
    public string RoleId { get; set; }
}