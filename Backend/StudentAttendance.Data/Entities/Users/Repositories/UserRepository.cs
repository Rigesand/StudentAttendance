using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Repositories;

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
        var result = await _context.Users
            .FirstOrDefaultAsync(it => it.Email.ToLower() == email.ToLower());
        if (result == null)
        {
            return null!;
        }

        var coreUser = _mapper.Map<User>(result);
        return coreUser;
    }

    public async Task<User> CreateAsync(User user)
    {
        var dbUser = _mapper.Map<UserDb>(user);
        await _context.Users.AddAsync(dbUser);
        return user;
    }

    public async Task UpdateUser(User user)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(it => it.Email == user.Email);
        dbUser!.Role = user.Role;
    }

    public async Task Delete(User user)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(it => it.Email == user.Email);
        if (dbUser == null)
        {
            throw new Exception("Такого пользователя не существует");
        }

        _context.Users.Remove(dbUser);
    }

    public async Task<User> GetUserById(Guid id)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<User>(dbUser);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _mapper.ProjectTo<User>(_context.Users).ToListAsync();
    }
}