namespace StudentAttendance.Core.Domains.Users.Repositories;

public interface IUserRepository
{
    public Task<User> FindByEmailAsync(string email);
    public Task<User> CreateAsync(User newUser, string password, string role);
    Task<IEnumerable<User>> GetAllUsers();
    public Task<bool> Delete(User user);
}