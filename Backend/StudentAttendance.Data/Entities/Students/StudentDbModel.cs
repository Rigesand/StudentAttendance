using StudentAttendance.Data.Entities.Groups;
using StudentAttendance.Data.Entities.VisitedStudents;

namespace StudentAttendance.Data.Entities.Students;

public class StudentDbModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid GroupId { get; set; }
    public GroupDbModel? GroupDbModel { get; set; }
    public ICollection<VisitedStudentDbModel>? VisitedStudents { get; set; }
}