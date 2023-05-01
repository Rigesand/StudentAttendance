namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class AttendanceDto
{
    public DateTimeOffset Data { get; set; }
    public Guid LessonId { get; set; }
    public ICollection<AttendingLessonDto> StudentAttendances { get; set; }
}