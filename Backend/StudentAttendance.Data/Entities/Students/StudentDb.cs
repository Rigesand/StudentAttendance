using StudentAttendance.Data.Entities.Groups;

namespace StudentAttendance.Data.Entities.Students;

public class StudentDb
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; } 
    public Guid GroupId { get; set; }
    public GroupDb GroupDb { get; set; } = null!;
}