namespace StudentAttendance.Api.Controllers.Lessons.Dto;

public class LessonRequest
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = null!;
}