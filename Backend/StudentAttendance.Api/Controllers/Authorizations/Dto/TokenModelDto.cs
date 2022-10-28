namespace StudentAttendance.Api.Controllers.Authorizations.Dto;

public class TokenModelDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}