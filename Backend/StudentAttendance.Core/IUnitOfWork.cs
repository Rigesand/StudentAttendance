namespace StudentAttendance.Core;

public interface IUnitOfWork
{
    Task<int> SaveChanges();
}