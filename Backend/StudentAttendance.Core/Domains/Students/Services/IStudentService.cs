namespace StudentAttendance.Core.Domains.Students.Services;

public interface IStudentService
{
    Task CreateStudent(Student student);
    Task UpdateStudent(Student updateStudent);
    Task Delete(Student student);
    Task<IEnumerable<Student>> GetStudentsByGroup(string groupNumber);
}