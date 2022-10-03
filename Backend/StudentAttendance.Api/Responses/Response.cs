namespace StudentAttendance.Api.Responses;

public class Response
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public bool Success { get; set; }
    public List<string>? Errors { get; set; }
}