using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Attendances.Repositories;
using StudentAttendance.Core.Domains.Groups.Repositories;

namespace StudentAttendance.Data.Entities.Attendances.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public AttendanceRepository(StudentAttendanceDbContext context, IMapper mapper, IGroupRepository groupRepository)
    {
        _context = context;
        _mapper = mapper;
        _groupRepository = groupRepository;
    }

    public async Task Add(Attendance attendance)
    {
        var group = await _groupRepository.GetIdByGroupNumber(attendance.GroupNumber);
        attendance.GroupId = group;
        var attendanceDb = _mapper.Map<AttendanceDb>(attendance);
        await _context.Attendances.AddAsync(attendanceDb);
    }

    public async Task<Attendance> GetAttendanceFromData(Attendance attendance)
    {
        var group = await _groupRepository.GetIdByGroupNumber(attendance.GroupNumber);
        attendance.GroupId = group;

        var attendanceDb = await _context.Attendances
            .AsNoTracking()
            .Include(a => a.StudentAttendances)
            .FirstOrDefaultAsync(it => it.Data.Date == attendance.Data.Date
                                       && it.LessonId == attendance.LessonId
                                       && it.GroupId == attendance.GroupId);
        return _mapper.Map<Attendance>(attendanceDb);
    }

    public async Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, string groupNumber)
    {
        var info = new LessonAttendanceInfo();

        var attendances = await GetAttenanceByLessondAndGroup(lessonId, groupNumber);
        var all = attendances
            .SelectMany(it => it.StudentAttendances).Count();
        info.Visited = attendances
            .SelectMany(it => it.StudentAttendances.Where(s => s.Status)).Count();
        info.Absence = all - info.Visited;
        return info;
    }

    private async Task<IQueryable<AttendanceDb>> GetAttenanceByLessondAndGroup(Guid lessonId, string groupNumber)
    {
        var group = await _groupRepository.GetIdByGroupNumber(groupNumber);
        return _context.Attendances
            .Where(it => it.GroupId == group && it.LessonId == lessonId)
            .Include(it => it.StudentAttendances);
    }

    public async Task<LessonAttendanceInfo> GetInfoAttendanceByDate(Guid lessonId, string groupNumber,
        DateTimeOffset date)
    {
        var info = new LessonAttendanceInfo();

        var attendances = await GetAttenanceByLessondAndGroup(lessonId, groupNumber);
        var all = attendances.Where(it => it.Data.Date == date.Date)
            .SelectMany(it => it.StudentAttendances).Count();
        info.Visited = attendances.Where(it => it.Data.Date == date.Date)
            .SelectMany(it => it.StudentAttendances.Where(s => s.Status)).Count();
        info.Absence = all - info.Visited;
        return info;
    }

    public async Task<LessonAttendanceInfo> GetAttendanceByStudent(Guid studentId, Guid lessonId, string groupNumber)
    {
        var info = new LessonAttendanceInfo();
        var attendances = await GetAttenanceByLessondAndGroup(lessonId, groupNumber);

        info.Visited = attendances
            .SelectMany(it => it.StudentAttendances)
            .Count(st => st.StudentId == studentId && st.Status);
        info.Absence = attendances
            .SelectMany(it => it.StudentAttendances)
            .Count(st => st.StudentId == studentId && !st.Status);

        return info;
    }
}