namespace StudentAttendance.Core.Domains.Roles.Repositories;

public interface IRoleRepository
{
    public Task<Role> CreateAsync(Role roleDbModel);
    public Task<Role> FindByNameAsync(string roleName);
    public Task<Role> FindById(string id);
}