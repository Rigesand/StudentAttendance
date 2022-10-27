using StudentAttendance.Data.Entities.Users;

namespace StudentAttendance.Data.Entities.Roles;

public class RoleDbModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserDbModel>? Users { get; set; }
}