using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Core.Domains.Roles;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<User>? Users { get; set; }
}