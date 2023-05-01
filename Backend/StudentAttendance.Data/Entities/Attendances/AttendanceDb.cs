using StudentAttendance.Data.Entities.Lessons;

namespace StudentAttendance.Data.Entities.Attendances;

public class AttendanceDb
{
    public Guid Id { get; set; }
    public DateTimeOffset Data { get; set; }
    public Guid LessonId { get; set; }
    public LessonDb Lesson { get; set; }
    public ICollection<AttendingLessonDb> StudentAttendances { get; set; }
}