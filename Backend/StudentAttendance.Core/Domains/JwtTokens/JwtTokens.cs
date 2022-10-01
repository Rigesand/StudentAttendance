namespace StudentAttendance.Core.Domains.JwtTokens;

public class JwtTokens
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public bool Success { get; set; }
    public List<string>? Errors { get; set; }
}