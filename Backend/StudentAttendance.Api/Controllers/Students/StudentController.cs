using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Students.Dto;
using StudentAttendance.Core.Domains.Students;
using StudentAttendance.Core.Domains.Students.Services;

namespace StudentAttendance.Api.Controllers.Students;

[ApiController]
[Authorize(Roles = "Студент")]
[Route("api/[controller]/[action]")]
public class StudentController:ControllerBase
{
    private readonly IStudentService _service;
    private readonly IMapper _mapper;

    public StudentController(IStudentService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task CreateStudent(CreateStudent student)
    {
        var studentCore = _mapper.Map<Student>(student);
        await _service.CreateStudent(studentCore);
    }
    
    
}