namespace StudentAttendance.Api.Controllers.Students.Dto;

public class StudentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int GroupNumber { get; set; }
}