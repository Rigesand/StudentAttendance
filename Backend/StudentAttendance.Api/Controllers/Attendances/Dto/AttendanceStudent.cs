namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class AttendanceStudent
{
    public Guid StudentId { get; set; }
    public Guid LessonId { get; set; }
    public string GroupNumber { get; set; } = null!;
}