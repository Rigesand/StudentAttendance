namespace StudentAttendance.Core.Domains.Students.Repositories;

public interface IStudentRepository
{
    Task CreateStudent(Student student);
    Task UpdateStudent(Student updateStudent);
    Task Delete(Student student);
}