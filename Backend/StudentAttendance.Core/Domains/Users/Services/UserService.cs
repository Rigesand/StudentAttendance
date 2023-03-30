using StudentAttendance.Core.Domains.Mail.Services;
using StudentAttendance.Core.Domains.Roles.Repositories;
using StudentAttendance.Core.Domains.Users.Repositories;
using StudentAttendance.Core.Exceptions;

namespace StudentAttendance.Core.Domains.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMailService _mailService;
    private readonly IUnitOfWork _unitOfWork;

    private string RandomString(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(x => x[random.Next(x.Length)]).ToArray());
    }

    public UserService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IMailService mailService,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _mailService = mailService;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null)
            throw new UserException("User not found");
        return user;
    }

    public async Task<User> GetUserByCredential(string login, string password)
    {
        var user = await _userRepository.FindByEmailAsync(login);
        if (user == null)
            throw new UserException("User not found");
        if (!HashService.Verify(password, user.PasswordHash))
            throw new Exception("Password is incorrect");
        return user;
    }


    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepository.FindByEmailAsync(email);
    }

    public async Task<User> CreateAndSendMailAsync(User user)
    {
        var password = RandomString(35);
        user.PasswordHash = HashService.GetHash(password);
        var existedRole = await _roleRepository.FindByNameAsync(user.Role);
        if (existedRole == null)
        {
            throw new Exception("Вы не можете создать пользователя с такой ролью");
        }

        var coreUser = await _userRepository.CreateAsync(user);
        await _unitOfWork.SaveChanges();
        await _mailService.Send(coreUser, password);
        return coreUser;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task UpdateUser(User user)
    {
        await _userRepository.UpdateUser(user);
        await _unitOfWork.SaveChanges();
    }

    public async Task Delete(User user)
    {
        await _userRepository.Delete(user);
        await _unitOfWork.SaveChanges();
    }
}