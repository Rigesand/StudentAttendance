namespace StudentAttendance.Core.Domains.Attendances.Repositories;

public interface IAttendanceRepository
{
    Task<int> AddAttendance(Attendance attendance);
}