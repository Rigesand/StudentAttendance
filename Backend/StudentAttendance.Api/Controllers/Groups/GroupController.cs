using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Core.Domains.Groups.Services;

namespace StudentAttendance.Api.Controllers.Groups;

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    public async Task CreateGroup(int groupNumber)
    {
        await _groupService.CreateGroup(groupNumber);
    }

    [HttpDelete]
    public async Task DeleteGroup(int groupNumber)
    {
        await _groupService.DeleteGroup(groupNumber);
    }
}