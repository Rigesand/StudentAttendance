namespace StudentAttendance.Core.Domains.Students.Repositories;

public interface IStudentRepository
{
    Task CreateStudent(Student student);
    Task Delete(Student student);
}