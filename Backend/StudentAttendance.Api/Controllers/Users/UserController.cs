using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentAttendance.Api.Controllers.Tokens.Dto;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Api.Responses;
using StudentAttendance.Core.Domains.JwtTokens;
using StudentAttendance.Core.Domains.JwtTokens.Services;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Services;
using StudentAttendance.Core.Exception;

namespace StudentAttendance.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly TokenValidationParameters _tokenValidationParams;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUserService _userService;

    public UserController(
        TokenValidationParameters tokenValidationParams,
        IUserService userService,
        IMapper mapper,
        IJwtTokenService jwtTokenService)
    {
        _tokenValidationParams = tokenValidationParams;
        _userService = userService;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateUserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUserAndSendEmail([FromBody] CreateUserDto newUser)
    {
        if (newUser.Email == null)
        {
            throw new ValidationException("Invalid payload");
        }

        var existedUser = await _userService.FindByEmailAsync(newUser.Email);

        if (existedUser != null)
        {
            throw new ValidationException("Email already in use");
        }

        var newUserCore = _mapper.Map<CreateUserDto, User>(newUser);
        var user = await _userService.CreateAndSendMailAsync(newUserCore, newUser.Role!);

        await _jwtTokenService.GenerateJwtToken(user);

        return Ok(newUser);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        if (loginUserDto.Email == null || loginUserDto.Password == null)
        {
            throw new ValidationException("Invalid payload");
        }

        var existingUser = await _userService.FindByEmailAsync(loginUserDto.Email);
        if (existingUser == null)
        {
            throw new ValidationException("Invalid login request");
        }

        var isCorrect = await _userService.CheckPasswordAsync(existingUser, loginUserDto.Password);

        if (isCorrect)
        {
            throw new ValidationException("Invalid login request");
        }

        var tokens = await _jwtTokenService.GenerateJwtToken(existingUser);

        var response = _mapper.Map<JwtTokens, Response>(tokens);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto tokenRequestDto)
    {
        var tokens = _mapper.Map<TokenRequestDto, JwtTokens>(tokenRequestDto);

        var jwtTokens = await _jwtTokenService.VerifyAndGenerateToken(tokens, _tokenValidationParams);

        if (jwtTokens == null)
        {
            throw new ValidationException("Invalid tokens");
        }

        var response = _mapper.Map<JwtTokens, Response>(jwtTokens);
        return Ok(response);
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
}