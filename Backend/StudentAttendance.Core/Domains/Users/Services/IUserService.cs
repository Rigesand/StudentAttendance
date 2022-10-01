namespace StudentAttendance.Core.Domains.Users.Services;

public interface IUserService
{
    public Task<User> FindByEmailAsync(string email);
    public Task<bool> CheckPasswordAsync(User newUser, string password);
    public Task<bool> CreateAsync(User newUser, string password);
    public Task<User> FindByIdAsync(string id);
}