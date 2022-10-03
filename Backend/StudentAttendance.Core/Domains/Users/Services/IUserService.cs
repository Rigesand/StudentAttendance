namespace StudentAttendance.Core.Domains.Users.Services;

public interface IUserService
{
    public Task<User> FindByEmailAsync(string email);
    public Task<bool> CheckPasswordAsync(User newUser, string password);
    public Task<User> CreateAndSendMailAsync(User newUser, string role);
    public Task<User> FindByIdAsync(string id);
    Task<IEnumerable<User>> GetAllUsers();
}