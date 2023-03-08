using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = "Администратор")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IValidator<UserRequest> _createValidator;

    public UserController(IUserService userService,
        IMapper mapper,
        IValidator<UserRequest> createValidator)
    {
        _userService = userService;
        _mapper = mapper;
        _createValidator = createValidator;
    }

    [HttpPost]
    public async Task CreateUserAndSendEmail(UserRequest user)
    {
        await _createValidator.ValidateAndThrowAsync(user);
        var userCore = _mapper.Map<User>(user);
        await _userService.CreateAndSendMailAsync(userCore);
    }

    [HttpGet]
    public async Task<IEnumerable<UserResponse>> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return _mapper.Map<IEnumerable<UserResponse>>(users);
    }

    [HttpPut]
    public async Task UpdateUser(UserRequest user)
    {
        var updateUser = _mapper.Map<User>(user);
        await _userService.UpdateUser(updateUser);
    }

    [HttpPost]
    public async Task DeleteUser(UserRequest userDto)
    {
        var coreUser = _mapper.Map<User>(userDto);
        await _userService.Delete(coreUser);
    }
}