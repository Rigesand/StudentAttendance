namespace StudentAttendance.Core.Domains.Users.Repositories;

public interface IUserRepository
{
    Task<User> FindByEmailAsync(string email);
    Task<User> CreateAsync(User user);
    Task<IEnumerable<User>> GetAllUsers();
    Task Delete(User user);
    Task<User> GetUserById(Guid id);
    Task UpdateUser(User user);
}