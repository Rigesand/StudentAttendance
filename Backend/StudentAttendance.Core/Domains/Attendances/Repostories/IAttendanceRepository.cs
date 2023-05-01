namespace StudentAttendance.Core.Domains.Attendances.Repostories;

public interface IAttendanceRepository
{
    Task Add(Attendance attendance);
}