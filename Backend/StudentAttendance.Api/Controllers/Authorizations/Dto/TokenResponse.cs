namespace StudentAttendance.Api.Controllers.Authorizations.Dto;

public class TokenResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}