using StudentAttendance.Data.Entities.Attendances;
using StudentAttendance.Data.Entities.Students;

namespace StudentAttendance.Data.Entities.VisitedStudents;

public class VisitedStudentDbModel
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }

    public bool IsVisited { get; set; }
    public StudentDbModel? Student { get; set; }
    public Guid AttendanceId { get; set; }
    public AttendanceDbModel? Attendance { get; set; }
}