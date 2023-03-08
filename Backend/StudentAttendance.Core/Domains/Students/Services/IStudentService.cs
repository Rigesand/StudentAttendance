namespace StudentAttendance.Core.Domains.Students.Services;

public interface IStudentService
{
    Task CreateStudent(Student student);
}