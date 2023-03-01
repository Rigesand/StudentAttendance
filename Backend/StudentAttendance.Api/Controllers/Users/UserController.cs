using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Services;
using StudentAttendance.Core.Exceptions;

namespace StudentAttendance.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = "Администратор")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IValidator<CreateUserDto> _createValidator;

    public UserController(IUserService userService,
        IMapper mapper,
        IValidator<CreateUserDto> createValidator)
    {
        _userService = userService;
        _mapper = mapper;
        _createValidator = createValidator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateUserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task CreateUserAndSendEmail([FromBody] CreateUserDto newUser)
    {
        await _createValidator.ValidateAndThrowAsync(newUser);
        var newUserCore = _mapper.Map<CreateUserDto, User>(newUser);
        await _userService.CreateAndSendMailAsync(newUserCore);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        var response = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<bool> DeleteUser([FromBody] UserDto userDto)
    {
        var coreUser = _mapper.Map<User>(userDto);
        var result = await _userService.Delete(coreUser);
        return result;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<UserDto> GetCurrentUser()
    {
        var userIdString = User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
        if (Guid.TryParse(userIdString, out var userId))
        {
            var response = await _userService.GetUser(userId);
            return _mapper.Map<UserDto>(response);
        }

        throw new UserException("You are not authorized");
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task UpdateUser(UserDto user)
    {
        var updateUser = _mapper.Map<User>(user);
        await _userService.UpdateUser(updateUser);
    }
}