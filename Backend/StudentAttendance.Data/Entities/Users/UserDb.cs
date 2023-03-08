namespace StudentAttendance.Data.Entities.Users;

public class UserDb
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = null!;
    public int? GroupNumber { get; set; }
}