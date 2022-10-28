using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace StudentAttendance.Core.Configuration;

public class AuthConfig
{
    public const string Position = "auth";
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? Key { get; set; }
    public int LifeTime { get; set; }

    public SymmetricSecurityKey SymmetricSecurityKey() =>
        new(Encoding.UTF8.GetBytes(Key!));
}