using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Api.Controllers.Lessons.Dto;
using StudentAttendance.Core.Domains.Lessons;
using StudentAttendance.Core.Domains.Lessons.Services;

namespace StudentAttendance.Api.Controllers.Lessons;

[ApiController]
[Route("api/[controller]/[action]")]
public class LessonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILessonService _service;

    public LessonController(IMapper mapper, ILessonService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    public async Task Create(LessonRequest lesson)
    {
        var coreLesson = _mapper.Map<Lesson>(lesson);
        await _service.Create(coreLesson);
    }

    [HttpPut]
    public async Task Update(LessonRequest lesson)
    {
        var coreLesson = _mapper.Map<Lesson>(lesson);
        await _service.Update(coreLesson);
    }

    [HttpDelete]
    public async Task Delete(Guid id)
    {
        await _service.Delete(id);
    }

    [HttpGet]
    public async Task<IEnumerable<LessonResponse>> GetAll()
    {
        var lessons = await _service.GetAll();
        return _mapper.Map<IEnumerable<LessonResponse>>(lessons);
    }
}