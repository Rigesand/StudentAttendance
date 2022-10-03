namespace StudentAttendance.Core.Domains.Attendances.Services;

public interface IAttendanceService
{
    Task<Guid> AddAttendance(Attendance attendance);
}