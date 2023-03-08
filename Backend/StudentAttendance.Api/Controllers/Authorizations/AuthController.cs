using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Authorizations.Dto;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Core.Domains.Tokens.Services;
using StudentAttendance.Core.Domains.Users.Services;
using StudentAttendance.Core.Exceptions;

namespace StudentAttendance.Api.Controllers.Authorizations;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthController(ITokenService tokenService, IMapper mapper, IUserService userService)
    {
        _tokenService = tokenService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost]
    public async Task<TokenResponse> Login(LoginRequest model)
    {
        var response = await _tokenService.Login(model.Email, model.Password);
        return _mapper.Map<TokenResponse>(response);
    }

    [HttpPost]
    public async Task<TokenResponse> GetRefreshToken(RefreshTokenRequest model)
    {
        var response = await _tokenService.GetTokenByRefreshToken(model.RefreshToken);
        return _mapper.Map<TokenResponse>(response);
    }
    [HttpGet]
    public async Task<UserResponse> GetCurrentUser()
    {
        var userIdString = User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
        if (Guid.TryParse(userIdString, out var userId))
        {
            var response = await _userService.GetUserById(userId);
            return _mapper.Map<UserResponse>(response);
        }

        throw new UserException("You are not authorized");
    }
}