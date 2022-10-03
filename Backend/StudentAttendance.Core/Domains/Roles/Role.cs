using Microsoft.AspNetCore.Identity;
using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Core.Domains.Roles;

public class Role : IdentityRole
{
    public Role(string role) : base(role)
    {
    }

    public Role()
    {
    }

    public string? UserId { get; set; }
    public ICollection<User>? Users { get; set; }
}