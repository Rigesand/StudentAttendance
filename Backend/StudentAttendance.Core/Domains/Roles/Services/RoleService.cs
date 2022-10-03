using StudentAttendance.Core.Domains.Roles.Repositories;
using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Core.Domains.Roles.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role> GetRole(User? user)
    {
        var role = await _roleRepository.FindById(user.RoleId);
        return role;
    }
}