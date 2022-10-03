using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Users.Dto;

public class LoginUserDto
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
}