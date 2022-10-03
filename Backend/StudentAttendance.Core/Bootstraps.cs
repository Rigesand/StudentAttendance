using Microsoft.Extensions.DependencyInjection;
using StudentAttendance.Core.Domains.Attendances.Services;
using StudentAttendance.Core.Domains.JwtTokens.Services;
using StudentAttendance.Core.Domains.Mail.Services;
using StudentAttendance.Core.Domains.RefreshTokens.Services;
using StudentAttendance.Core.Domains.Roles.Services;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Core;

public static class Bootstraps
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IRoleService, RoleService>();
        return services;
    }
}