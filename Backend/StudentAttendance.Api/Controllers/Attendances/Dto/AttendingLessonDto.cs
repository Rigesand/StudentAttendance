namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class AttendingLessonDto
{
    public Guid StudentId { get; set; }
    public bool Status { get; set; }
}