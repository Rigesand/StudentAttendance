using StudentAttendance.Core.Domains.Lessons.Repositories;

namespace StudentAttendance.Core.Domains.Lessons.Services;

public class LessonService : ILessonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILessonRepository _repository;

    public LessonService(IUnitOfWork unitOfWork, ILessonRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Create(Lesson lesson)
    {
        await _repository.Create(lesson);
        await _unitOfWork.SaveChanges();
    }

    public async Task Update(Lesson lesson)
    {
        await _repository.Update(lesson);
        await _unitOfWork.SaveChanges();
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Lesson>> GetAll()
    {
        return await _repository.GetAll();
    }
}