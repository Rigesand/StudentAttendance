using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Groups.Dto;
using StudentAttendance.Core.Domains.Groups.Services;

namespace StudentAttendance.Api.Controllers.Groups;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = "Администратор")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;

    public GroupController(IGroupService groupService, IMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task CreateGroup(string groupNumber)
    {
        await _groupService.CreateGroup(groupNumber);
    }

    [HttpDelete]
    public async Task DeleteGroup(string groupNumber)
    {
        await _groupService.DeleteGroup(groupNumber);
    }

    [HttpGet]
    public async Task<IEnumerable<GroupResponse>> GetAllGroups()
    {
        var groups = await _groupService.GetAllGroup();
        return _mapper.Map<IEnumerable<GroupResponse>>(groups);
    }
}