using StudentAttendance.Core.Domains.Students;

namespace StudentAttendance.Core.Domains.Groups;

public class Group
{
    public Guid Id { get; set; }
    public int GroupNumber { get; set; }
    public ICollection<Student>? Students { get; set; }
}