using StudentAttendance.Core.Domains.Attendances.Repostories;

namespace StudentAttendance.Core.Domains.Attendances.Services;

public class AttendanceService: IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AttendanceService(IAttendanceRepository attendanceRepository, IUnitOfWork unitOfWork)
    {
        _attendanceRepository = attendanceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(Attendance attendance)
    {
        await _attendanceRepository.Add(attendance);
        await _unitOfWork.SaveChanges();
    }
}