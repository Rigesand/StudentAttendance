namespace StudentAttendance.Core.Domains.Users.Services;

public interface IUserService
{
    Task<User> GetUserById(Guid id);
    Task<User> GetUserByCredential(string login, string password);
    Task<User> GetUserByEmail(string email);
    Task<User> CreateAndSendMailAsync(User user);
    Task<IEnumerable<User>> GetAllUsers();
    Task UpdateUser(User user);
    Task Delete(User user);
}