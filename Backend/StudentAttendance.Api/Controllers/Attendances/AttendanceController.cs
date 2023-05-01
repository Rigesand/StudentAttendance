using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Attendances.Dto;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Attendances.Services;

namespace StudentAttendance.Api.Controllers.Attendances;

[ApiController]
[Route("api/[controller]/[action]")]
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
    public async Task Add(AttendanceDto attendanceDto)
    {
        var attendance = _mapper.Map<Attendance>(attendanceDto);
        await _service.Add(attendance);
    }
}