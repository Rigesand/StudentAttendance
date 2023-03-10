namespace StudentAttendance.Core.Domains.Students.Repositories;

public interface IStudentRepository
{
    Task CreateStudent(Student student);
    Task UpdateUser(Student updateStudent);
    Task Delete(Student student);
}