using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Profiles.Dto;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Api.Controllers.Profiles;

[ApiController]
[Authorize]
[Route("api/[controller]/[action]")]
public class ProfileController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public ProfileController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task ChangeUserData(ProfileRequest profileRequest)
    {
        var user = _mapper.Map<User>(profileRequest);
        await _userService.UpdateUser(user);
    }
}