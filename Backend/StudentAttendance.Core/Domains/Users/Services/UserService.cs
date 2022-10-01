using StudentAttendance.Core.Domains.Users.Repositories;

namespace StudentAttendance.Core.Domains.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _userRepository.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(User newUser, string password)
    {
        return await _userRepository.CheckPasswordAsync(newUser, password);
    }

    public async Task<bool> CreateAsync(User newUser, string password)
    {
        return await _userRepository.CreateAsync(newUser, password);
    }

    public async Task<User> FindByIdAsync(string id)
    {
        return await _userRepository.FindByIdAsync(id);
    }
}