using Microsoft.AspNetCore.Identity;
using StudentAttendance.Core.Domains.RefreshTokens;
using StudentAttendance.Core.Domains.Roles;

namespace StudentAttendance.Core.Domains.Users;

public class User : IdentityUser
{
    public RefreshToken? RefreshToken { get; set; }
    public Role? Role { get; set; }
    public string RoleId { get; set; }
    
    public string RoleName { get; set; }
}