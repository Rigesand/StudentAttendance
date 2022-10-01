using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Attendances.Dto;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Attendances.Services;

namespace StudentAttendance.Api.Controllers.Attendances;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _service;
    private readonly IMapper _mapper;

    public AttendanceController(IAttendanceService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<int> AddAttendance([FromBody] AddAttendanceDto attendanceDto)
    {
        var attendance = _mapper.Map<AddAttendanceDto, Attendance>(attendanceDto);
        var id = await _service.AddAttendance(attendance);
        return id;
    }
}