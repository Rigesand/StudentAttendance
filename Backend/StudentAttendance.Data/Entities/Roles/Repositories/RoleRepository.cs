using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.Roles;
using StudentAttendance.Core.Domains.Roles.Repositories;

namespace StudentAttendance.Data.Entities.Roles.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;

    public RoleRepository(StudentAttendanceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Role> CreateAsync(Role roleDbModel)
    {
        var roleDb = _mapper.Map<Role, RoleDb>(roleDbModel);
        await _context.Roles.AddAsync(roleDb);
        return roleDbModel;
    }

    public async Task<Role> FindByNameAsync(string roleName)
    {
        var roleDbModel = await _context.Roles.FirstOrDefaultAsync(it => it.Name == roleName);
        if (roleDbModel == null)
        {
            return null!;
        }

        var coreRole = _mapper.Map<RoleDb, Role>(roleDbModel);
        return coreRole;
    }
}