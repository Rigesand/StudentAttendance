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
        var dbLesson = await _context.Lessons.FirstOrDefaultAsync(it => it.Id == lesson.Id);
        if (dbLesson == null)
        {
            throw new Exception("Такого предмета не существует");
        }

        dbLesson.Name = lesson.Name;
    }

    public async Task Delete(Guid id)
    {
        var dbLesson = await _context.Lessons.FirstOrDefaultAsync(it => it.Id == id);
        if (dbLesson == null)
        {
            throw new Exception("Такого предмета не существует");
        }

        _context.Lessons.Remove(dbLesson);
    }

    public async Task<IEnumerable<Lesson>> GetAll()
    {
        return await _mapper.ProjectTo<Lesson>(_context.Lessons).ToListAsync();
    }
}