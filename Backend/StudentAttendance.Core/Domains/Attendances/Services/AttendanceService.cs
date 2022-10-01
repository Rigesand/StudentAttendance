using StudentAttendance.Core.Domains.Attendances.Repositories;

namespace StudentAttendance.Core.Domains.Attendances.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repository;

    public AttendanceService(IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddAttendance(Attendance attendance)
    {
        attendance.Date = DateTimeOffset.Now;
        var id = await _repository.AddAttendance(attendance);
        return id;
    }
}