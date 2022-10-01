using StudentAttendance.Data.Entities.Users;

namespace StudentAttendance.Data.Entities.RefreshTokens;

public class RefreshTokenDbModel
{
    public Guid Id { get; set; }
    public string? UserId { get; set; }
    public string? Token { get; set; }
    public string? JwtId { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevorked { get; set; }
    public DateTimeOffset AddedDate { get; set; }
    public DateTimeOffset ExpiryDate { get; set; }
    public UserDbModel? User { get; set; }
}