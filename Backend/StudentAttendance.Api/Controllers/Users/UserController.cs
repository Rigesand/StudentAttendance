using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentAttendance.Api.Configuration;
using StudentAttendance.Api.Controllers.Tokens.Dto;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Api.Responses;
using StudentAttendance.Core.Domains.JwtTokens;
using StudentAttendance.Core.Domains.JwtTokens.Services;
using StudentAttendance.Core.Domains.Mail.Services;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly TokenValidationParameters _tokenValidationParams;
    private readonly IUserService _userService;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IConfiguration _configuration;

    public UserController(
        TokenValidationParameters tokenValidationParams,
        IUserService userService,
        IMapper mapper,
        IJwtTokenService jwtTokenService,
        IMailService mailService,
        IConfiguration configuration)
    {
        _tokenValidationParams = tokenValidationParams;
        _userService = userService;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
        _mailService = mailService;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        if (userDto.Email == null || userDto.Password == null)
        {
            return BadRequest(new RegistrationResponse
            {
                Errors = new List<string>
                {
                    "Invalid payload"
                },
                Success = false
            });
        }

        var existedUser = await _userService.FindByEmailAsync(userDto.Email);

        if (existedUser != null)
        {
            return BadRequest(new RegistrationResponse
            {
                Errors = new List<string>
                {
                    "Email or Password already in use"
                },
                Success = false
            });
        }

        var newUser = _mapper.Map<UserDto, User>(userDto);
        newUser.UserName = userDto.Email;

        await _userService.CreateAsync(newUser, userDto.Password);
        await _jwtTokenService.GenerateJwtToken(newUser, _configuration["SecretSettings:Secret"]);
        await _mailService.Send(newUser, userDto.Password);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserDto userDto)
    {
        if (userDto.Email == null || userDto.Password == null)
        {
            return BadRequest(new AuthResponse()
            {
                Errors = new List<string>
                {
                    "Invalid payload"
                },
                Success = false
            });
        }

        var existingUser = await _userService.FindByEmailAsync(userDto.Email);
        if (existingUser == null)
        {
            return BadRequest(new AuthResponse
            {
                Errors = new List<string>
                {
                    "Invalid login request"
                },
                Success = false
            });
        }

        var isCorrect = await _userService.CheckPasswordAsync(existingUser, userDto.Password);

        if (isCorrect)
        {
            return BadRequest(new AuthResponse
            {
                Errors = new List<string>
                {
                    "Invalid login request"
                },
                Success = false
            });
        }

        var tokens = await _jwtTokenService.GenerateJwtToken(existingUser, _configuration["SecretSettings:Secret"]);

        var response = _mapper.Map<JwtTokens, AuthResponse>(tokens);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto tokenRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new RegistrationResponse
            {
                Errors = new List<string>
                {
                    "Invalid payload"
                },
                Success = false
            });
        }

        var tokens = _mapper.Map<TokenRequestDto, JwtTokens>(tokenRequestDto);
        var result =
            await _jwtTokenService.VerifyAndGenerateToken(tokens, _tokenValidationParams, _configuration["SecretSettings:Secret"]);
        if (result == null)
        {
            return BadRequest(new RegistrationResponse
            {
                Errors = new List<string>
                {
                    "Invalid tokens"
                },
                Success = false
            });
        }

        var response = _mapper.Map<JwtTokens, AuthResponse>(result);
        return Ok(response);
    }
}