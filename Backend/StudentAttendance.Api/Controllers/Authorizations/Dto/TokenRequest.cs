using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Authorizations.Dto;

public class TokenRequest
{
    [Required]
    public string? Login { get; set; }
    [Required]
    public string? Password { get; set; }
}