using Microsoft.AspNetCore.Identity;
using StudentAttendance.Data.Entities.Users;

namespace StudentAttendance.Data.Entities.Roles;

public class RoleDbModel : IdentityRole
{
    public RoleDbModel(string role) : base(role)
    {
    }

    public RoleDbModel()
    {
    }

    public ICollection<UserDbModel>? Users { get; set; }
}