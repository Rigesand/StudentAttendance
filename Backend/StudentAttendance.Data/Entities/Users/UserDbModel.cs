using StudentAttendance.Data.Entities.Roles;

namespace StudentAttendance.Data.Entities.Users;

public class UserDbModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public RoleDbModel? Role { get; set; }
    public Guid? RoleId { get; set; }
    public string? RoleName { get; set; }
}