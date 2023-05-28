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

    [HttpPost]
    public async Task<AttendanceDto> GetAttendanceFromData(FilterDate request)
    {
        var attendanceDb = _mapper.Map<Attendance>(request);
        var attendance = await _service.GetAttendanceFromData(attendanceDb);
        return _mapper.Map<AttendanceDto>(attendance);
    }

    [HttpPost]
    public async Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, string groupNumber)
    {
        return await _service.GetAttendance(lessonId, groupNumber);
    }

    [HttpPost]
    public async Task<IEnumerable<LessonAttendanceInfo>> GetLessonsInfo(FilterTimeSpan filter)
    {
        return await _service.GetLessonsInfo(filter.LessonId, filter.GroupNumber, filter.BeginDate, filter.EndDate);
    }

    [HttpPost]
    public async Task<LessonAttendanceInfo> GetAttendanceByStudent(AttendanceStudent attendance)
    {
        return await _service.GetAttendanceByStudent(attendance.StudentId, attendance.LessonId, attendance.GroupNumber);
    }
}