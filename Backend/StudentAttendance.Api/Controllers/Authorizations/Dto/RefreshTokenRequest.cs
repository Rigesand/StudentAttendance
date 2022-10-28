using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Authorizations.Dto;

public class RefreshTokenRequest
{
    [Required] 
    public string? RefreshToken { get; set; }
}