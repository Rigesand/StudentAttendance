namespace StudentAttendance.Core.Domains.Tokens;

public class TokenModel
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}