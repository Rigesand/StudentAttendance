using StudentAttendance.Core.Domains.Students;

namespace StudentAttendance.Core.Domains.Groups;

public class Group
{
    public Guid Id { get; set; }
    public string GroupNumber { get; set; } = null!;
    public ICollection<Student>? Students { get; set; }
}