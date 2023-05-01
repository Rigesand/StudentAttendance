namespace StudentAttendance.Core.Domains.Attendances.Services;

public interface IAttendanceService
{
    Task Add(Attendance attendance);
}