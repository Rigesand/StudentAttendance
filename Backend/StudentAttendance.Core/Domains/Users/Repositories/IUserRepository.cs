namespace StudentAttendance.Core.Domains.Users.Repositories;

public interface IUserRepository
{
    public Task<User> FindByEmailAsync(string email);
    public Task<bool> CheckPasswordAsync(User newUser, string password);
    public Task<User> CreateAsync(User newUser, string password, string role);
    public Task<User> FindByIdAsync(string id);
    Task<IEnumerable<User>> GetAllUsers();
    public Task<bool> Delete(User user);
}