using AutoMapper;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Attendances.Repostories;

namespace StudentAttendance.Data.Entities.Attendances.Repositories;

public class AttendanceRepository: IAttendanceRepository
{
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;

    public AttendanceRepository(StudentAttendanceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Add(Attendance attendance)
    {
        var attendanceDb = _mapper.Map<AttendanceDb>(attendance);
        await _context.Attendances.AddAsync(attendanceDb);
    }
}