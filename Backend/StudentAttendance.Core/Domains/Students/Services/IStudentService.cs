namespace StudentAttendance.Core.Domains.Students.Services;

public interface IStudentService
{
    Task CreateStudent(Student student);
    Task<IEnumerable<Student>> GetStudentsByGroup(int groupNumber);
    Task Delete(Student student);
}