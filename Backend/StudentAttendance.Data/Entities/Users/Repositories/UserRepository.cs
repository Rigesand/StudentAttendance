using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Repositories;
using StudentAttendance.Data.Entities.Roles;

namespace StudentAttendance.Data.Entities.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(StudentAttendanceDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        var result = await _context.Users.FirstOrDefaultAsync(it => it.Email == email);
        if (result == null)
        {
            return null!;
        }

        var coreUser = _mapper.Map<UserDbModel, User>(result);
        return coreUser;
    }

    public async Task<User> CreateAsync(User newUser, string password, string role)
    {
        var dbUser = _mapper.Map<User, UserDbModel>(newUser);

        var dbRole = await _context.Roles.FirstOrDefaultAsync(it => it.Name == role);
        dbUser.Role = dbRole;
        dbUser.RoleName = dbRole.Name;
        await _context.Users.AddAsync(dbUser);

        var returnUser = _mapper.Map<UserDbModel, User>(dbUser);
        return returnUser;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _context.Users.Join(
                _context.Roles,
                u => u.RoleId,
                r => r.Id,
                (user, role) => new
                {
                    user.Email,
                    role.Name
                })
            .AsNoTracking()
            .ToListAsync();
        var coreUsers = new List<User>();
        foreach (var user in users)
        {
            coreUsers.Add(new User
            {
                Email = user.Email,
                RoleName = user.Name
            });
        }

        return coreUsers;
    }

    public async Task<bool> Delete(User user)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(it => it.Email == user.Email);
        if (dbUser == null)
        {
            return false;
        }

        _context.Users.Remove(dbUser);
        return true;
    }
}