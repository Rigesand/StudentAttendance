using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Authorizations.Dto;
using StudentAttendance.Core.Domains.Tokens.Services;

namespace StudentAttendance.Api.Controllers.Authorizations;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthController(ITokenService tokenService, IMapper mapper)
    {
        _tokenService = tokenService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenModelDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<TokenModelDto> Login([FromBody] TokenRequest model)
    {
        var response = await _tokenService.Login(model.Email!, model.Password!);
        return _mapper.Map<TokenModelDto>(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenModelDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<TokenModelDto> GetRefreshToken([FromBody] RefreshTokenRequest model)
    {
        var response = await _tokenService.GetTokenByRefreshToken(model.RefreshToken!);
        return _mapper.Map<TokenModelDto>(response);
    }
}