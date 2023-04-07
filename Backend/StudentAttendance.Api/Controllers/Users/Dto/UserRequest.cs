namespace StudentAttendance.Api.Controllers.Users.Dto;

public class UserRequest
{
    public Guid? Id { get; set; }
    public string Email { get; set; } = null!;
    public string GroupNumber { get; set; } = null!;
}