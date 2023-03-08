using Microsoft.Extensions.DependencyInjection;
using StudentAttendance.Core;
using StudentAttendance.Core.Domains.Groups.Repositories;
using StudentAttendance.Core.Domains.Roles.Repositories;
using StudentAttendance.Core.Domains.Students.Repositories;
using StudentAttendance.Core.Domains.Users.Repositories;
using StudentAttendance.Data.Entities.Groups.Repositories;
using StudentAttendance.Data.Entities.Roles.Repositories;
using StudentAttendance.Data.Entities.Students.Repositories;
using StudentAttendance.Data.Entities.Users.Repositories;

namespace StudentAttendance.Data;

public static class Bootstraps
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        return services;
    }
}