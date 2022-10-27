using StudentAttendance.Core.Domains.Roles;

namespace StudentAttendance.Core.Domains.Users;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Role? Role { get; set; }
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
}