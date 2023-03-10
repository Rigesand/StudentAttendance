using StudentAttendance.Core.Domains.Groups;

namespace StudentAttendance.Core.Domains.Students;

public class Student
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int GroupNumber { get; set; }
    public Guid GroupId { get; set; }
    public Group? GroupDbModel { get; set; }
}