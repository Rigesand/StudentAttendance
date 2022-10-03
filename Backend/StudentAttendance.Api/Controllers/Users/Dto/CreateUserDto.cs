using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Users.Dto;

public class CreateUserDto
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Role { get; set; }
}