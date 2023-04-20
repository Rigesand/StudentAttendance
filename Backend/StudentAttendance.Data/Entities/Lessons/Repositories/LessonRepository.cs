using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.Lessons;
using StudentAttendance.Core.Domains.Lessons.Repositories;

namespace StudentAttendance.Data.Entities.Lessons.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;

    public LessonRepository(StudentAttendanceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Create(Lesson lesson)
    {
        var isExist = await _context.Lessons.FirstOrDefaultAsync(it => it.Name == lesson.Name);
        if (isExist != null)
        {
            throw new Exception("Такой предмет уже существует");
        }

        var dbLesson = _mapper.Map<LessonDb>(lesson);
        await _context.Lessons.AddAsync(dbLesson);
    }

    public async Task Update(Lesson lesson)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Lesson>> GetAll()
    {
        throw new NotImplementedException();
    }
}