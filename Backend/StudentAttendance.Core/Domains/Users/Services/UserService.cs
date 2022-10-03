using StudentAttendance.Core.Domains.Mail.Services;
using StudentAttendance.Core.Domains.Roles;
using StudentAttendance.Core.Domains.Roles.Repositories;
using StudentAttendance.Core.Domains.Users.Repositories;

namespace StudentAttendance.Core.Domains.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMailService _mailService;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IUserRepository userRepository,
        IMailService mailService,
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _mailService = mailService;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _userRepository.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(User newUser, string password)
    {
        return await _userRepository.CheckPasswordAsync(newUser, password);
    }

    public async Task<User> CreateAndSendMailAsync(User newUser, string role)
    {
        var password = RandomString(35);
        var existedRole = await _roleRepository.FindByNameAsync(role);
        if (existedRole == null)
        {
            await _roleRepository.CreateAsync(new Role(role));
            await _unitOfWork.SaveChanges();
        }

        var user = await _userRepository.CreateAsync(newUser, password, role);
        await _unitOfWork.SaveChanges();
        await _mailService.Send(user, password);
        return user;
    }

    public async Task<User> FindByIdAsync(string id)
    {
        return await _userRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    private string RandomString(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(x => x[random.Next(x.Length)]).ToArray());
    }
}