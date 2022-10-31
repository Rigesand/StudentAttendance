using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Authorizations.Dto;

public class TokenRequest
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}