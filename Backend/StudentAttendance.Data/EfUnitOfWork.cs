using StudentAttendance.Core;

namespace StudentAttendance.Data;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly StudentAttendanceDbContext _context;

    public EfUnitOfWork(StudentAttendanceDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}