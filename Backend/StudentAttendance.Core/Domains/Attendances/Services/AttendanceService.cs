using StudentAttendance.Core.Domains.Attendances.Repositories;

namespace StudentAttendance.Core.Domains.Attendances.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AttendanceService(IAttendanceRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> AddAttendance(Attendance attendance)
    {
        attendance.Date = DateTimeOffset.Now;
        var id = await _repository.AddAttendance(attendance);
        await _unitOfWork.SaveChanges();
        return id;
    }
}