using StudentAttendance.Data.Entities.Students;

namespace StudentAttendance.Data.Entities.Attendances;

public class AttendingLessonDb
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public StudentDb Student { get; set; }
    public bool Status { get; set; }
    public Guid AttendanceDbId { get; set; }
    public AttendanceDb AttendanceDb { get; set; }
}