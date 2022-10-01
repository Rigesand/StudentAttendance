using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Users.Dto;

public class UserDto
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}