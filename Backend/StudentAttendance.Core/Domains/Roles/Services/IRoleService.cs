using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Core.Domains.Roles.Services;

public interface IRoleService
{
    public Task<Role> GetRole(User? user);
}