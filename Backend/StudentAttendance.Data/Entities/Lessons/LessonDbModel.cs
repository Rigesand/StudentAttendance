using StudentAttendance.Data.Entities.Attendances;

namespace StudentAttendance.Data.Entities.Lessons;

public class LessonDbModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public ICollection<AttendanceDbModel>? Attendances { get; set; }
}