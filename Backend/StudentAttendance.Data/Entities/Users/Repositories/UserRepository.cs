using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Repositories;

namespace StudentAttendance.Data.Entities.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(
        UserManager<IdentityUser> userManager,
        StudentAttendanceDbContext context,
        IMapper mapper)
    {
        _userManager = userManager;
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

    public async Task<bool> CheckPasswordAsync(User newUser, string password)
    {
        var passwordHash = _userManager.PasswordHasher.HashPassword(newUser, password);
        var result = await _context.Users.AnyAsync(it => it.PasswordHash == passwordHash);
        return result;
    }

    public async Task<User> CreateAsync(User newUser, string password, string role)
    {
        var dbUser = _mapper.Map<User, UserDbModel>(newUser);
        dbUser.PasswordHash = _userManager.PasswordHasher.HashPassword(dbUser, password);

        var dbRole = await _context.Roles.FirstOrDefaultAsync(it => it.Name == role);
        dbUser.Role = dbRole;
        await _context.Users.AddAsync(dbUser);

        var returnUser = _mapper.Map<UserDbModel, User>(dbUser);
        return returnUser;
    }

    public async Task<User> FindByIdAsync(string id)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(it => it.Id == id);
        if (dbUser == null)
        {
            return null!;
        }

        var coreUser = _mapper.Map<UserDbModel, User>(dbUser);
        return coreUser;
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
            coreUsers.Add(new User()
            {
                Email = user.Email,
                RoleName = user.Name
            });
        }

        return coreUsers;
    }
}