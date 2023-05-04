namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class AttendanceRequest
{
    public DateTimeOffset Data { get; set; }
    public Guid LessonId { get; set; }
    public string GroupNumber { get; set; } = null!;
}