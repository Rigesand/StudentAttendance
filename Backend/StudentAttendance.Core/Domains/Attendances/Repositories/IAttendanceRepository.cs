namespace StudentAttendance.Core.Domains.Attendances.Repositories;

public interface IAttendanceRepository
{
    Task<Guid> AddAttendance(Attendance attendance);
}