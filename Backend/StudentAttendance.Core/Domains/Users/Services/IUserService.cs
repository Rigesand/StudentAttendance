namespace StudentAttendance.Core.Domains.Users.Services;

public interface IUserService
{
    Task<User> FindByEmailAsync(string email);
    Task<User> CreateAndSendMailAsync(User newUser);
    Task<IEnumerable<User>> GetAllUsers();
    Task UpdateUser(User updateUser);
    Task<bool> Delete(User user);
    Task<User> GetUser(Guid id);
}