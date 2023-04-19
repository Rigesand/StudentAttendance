namespace StudentAttendance.Api.Controllers.Groups.Dto;

public class GroupResponse
{
    public Guid Id { get; set; }
    public string GroupNumber { get; set; } = null!;
}