namespace StudentAttendance.Core.Domains.Users.Repositories;

public interface IUserRepository
{
    Task<User> FindByEmailAsync(string email);
    Task<User> CreateAsync(User newUser);
    public Task<IEnumerable<User>> GetAllUsers();
    Task<bool> Delete(User user);
    Task<User> GetUserById(Guid id);
    Task UpdateUser(User updateUser);
}