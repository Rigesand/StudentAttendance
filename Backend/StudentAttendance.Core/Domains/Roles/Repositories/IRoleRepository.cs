namespace StudentAttendance.Core.Domains.Roles.Repositories;

public interface IRoleRepository
{
    Task<Role> CreateAsync(Role roleDbModel);
    Task<Role> FindByNameAsync(string roleName);
    Task<Role> FindById(Guid id);
}