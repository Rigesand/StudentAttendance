using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Users.Dto;

public class UserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }= null!;
    [Required] 
    public string Role { get; set; } = null!;
    public int? GroupNumber { get; set; }
}