namespace StudentAttendance.Core.Domains.Roles.Repositories;

public interface IRoleRepository
{
    Task<Role> FindByNameAsync(string roleName);
}