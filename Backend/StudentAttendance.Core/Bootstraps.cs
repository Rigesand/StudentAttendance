using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentAttendance.Core.Configuration;
using StudentAttendance.Core.Domains.Attendances.Services;
using StudentAttendance.Core.Domains.Mail.Services;
using StudentAttendance.Core.Domains.Tokens.Services;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Core;

public static class Bootstraps
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, UserService>();
        services.AddScoped<IMailService, MailService>();
        services.Configure<AuthConfig>(configuration.GetSection(AuthConfig.Position));
        return services;
    }
}