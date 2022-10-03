using AutoMapper;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Attendances.Repositories;

namespace StudentAttendance.Data.Entities.Attendances.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly IMapper _mapper;
    private readonly StudentAttendanceDbContext _context;

    public AttendanceRepository(IMapper mapper, StudentAttendanceDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Guid> AddAttendance(Attendance attendance)
    {
        var attendanceDb = _mapper.Map<Attendance, AttendanceDbModel>(attendance);
        attendanceDb.Id = Guid.NewGuid();
        await _context.Attendances.AddAsync(attendanceDb);
        return attendanceDb.Id;
    }
}