using Microsoft.Extensions.DependencyInjection;
using StudentAttendance.Core;
using StudentAttendance.Core.Domains.Attendances.Repositories;
using StudentAttendance.Core.Domains.Roles.Repositories;
using StudentAttendance.Core.Domains.Users.Repositories;
using StudentAttendance.Data.Entities.Attendances.Repositories;
using StudentAttendance.Data.Entities.Roles.Repositories;
using StudentAttendance.Data.Entities.Users.Repositories;

namespace StudentAttendance.Data;

public static class Bootstraps
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        return services;
    }
}