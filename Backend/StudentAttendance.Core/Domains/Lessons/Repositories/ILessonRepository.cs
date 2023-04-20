namespace StudentAttendance.Core.Domains.Lessons.Repositories;

public interface ILessonRepository
{
    Task Create(Lesson lesson);
    Task Update(Lesson lesson);
    Task Delete(Guid id);
    Task<IEnumerable<Lesson>> GetAll();
}