using StudentAttendance.Data.Entities.Students;

namespace StudentAttendance.Data.Entities.Groups;

public class GroupDb
{
    public Guid Id { get; set; }
    public int GroupNumber { get; set; }
    public ICollection<StudentDb>? Students { get; set; }
}