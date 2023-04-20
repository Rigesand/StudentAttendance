namespace StudentAttendance.Core.Domains.Lessons.Services;

public interface ILessonService
{
    Task Create(Lesson lesson);
    Task Update(Lesson lesson);
    Task Delete(Guid id);
    Task<IEnumerable<Lesson>> GetAll();
}