namespace StudentAttendance.Core.Domains.Users;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string GroupNumber { get; set; } = null!;
}