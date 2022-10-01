namespace StudentAttendance.Core.Domains.Attendances.Services;

public interface IAttendanceService
{
    Task<int> AddAttendance(Attendance attendance);
}