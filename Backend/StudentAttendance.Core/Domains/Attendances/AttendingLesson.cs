using StudentAttendance.Core.Domains.Students;

namespace StudentAttendance.Core.Domains.Attendances;

public class AttendingLesson
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public bool Status { get; set; }
    public Guid AttendanceId { get; set; }
    public Attendance Attendance { get; set; }
}