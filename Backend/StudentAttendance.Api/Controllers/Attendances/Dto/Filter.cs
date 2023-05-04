namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class Filter
{
    public string GroupNumber { get; set; } = null!;
    public Guid LessonId { get; set; }
}