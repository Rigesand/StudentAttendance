namespace StudentAttendance.Core.Domains.Users.Services;

public interface IUserService
{
    public Task<User> FindByEmailAsync(string email);
    public Task<User> CreateAndSendMailAsync(User newUser, string role);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task<bool> Delete(User user);
    public Task<User> GetUser(Guid id);
}