using StudentAttendance.Data.Entities.Groups;
using StudentAttendance.Data.Entities.Lessons;
using StudentAttendance.Data.Entities.VisitedStudents;

namespace StudentAttendance.Data.Entities.Attendances;

public class AttendanceDbModel
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid GroupId { get; set; }
    public GroupDbModel? GroupDbModel { get; set; }
    public LessonDbModel? Lesson { get; set; }
    public DateTimeOffset Date { get; set; }
    public ICollection<VisitedStudentDbModel>? VisitedStudents { get; set; }
}