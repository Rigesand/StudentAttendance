using StudentAttendance.Core.Domains.Lessons;

namespace StudentAttendance.Core.Domains.Attendances;

public class Attendance
{
    public Guid Id { get; set; }
    public DateTimeOffset Data { get; set; }
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public ICollection<AttendingLesson> StudentAttendances { get; set; }
}