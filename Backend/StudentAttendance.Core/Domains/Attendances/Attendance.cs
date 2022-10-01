using StudentAttendance.Core.Domains.VisitedStudents;

namespace StudentAttendance.Core.Domains.Attendances;

public class Attendance
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid GroupId { get; set; }
    public DateTimeOffset Date { get; set; }
    public ICollection<VisitedStudent>? VisitedStudents { get; set; }
}