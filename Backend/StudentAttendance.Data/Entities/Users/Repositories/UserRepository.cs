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

    public UserRepository(UserManager<IdentityUser> userManager, StudentAttendanceDbContext context, IMapper mapper)
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

    public async Task<bool> CreateAsync(User newUser, string password)
    {
        var dbUser = _mapper.Map<User, UserDbModel>(newUser);
        dbUser.PasswordHash = _userManager.PasswordHasher.HashPassword(newUser, password);
        await _context.Users.AddAsync(dbUser);
        await _context.SaveChangesAsync();
        return true;
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
}