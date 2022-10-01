namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class AddAttendanceDto
{
    public Guid LessonId { get; set; }
    public Guid GroupId { get; set; }
    public ICollection<VisitedStudentDto>? VisitedStudents { get; set; }
}