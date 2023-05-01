namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class AttendingLessonDto
{
    public string Name { get; set; }
    public Guid StudentId { get; set; }
    public bool Status { get; set; }
}