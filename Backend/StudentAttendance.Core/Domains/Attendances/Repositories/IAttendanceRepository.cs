namespace StudentAttendance.Core.Domains.Attendances.Repositories;

public interface IAttendanceRepository
{
    Task Add(Attendance attendance);
    Task<Attendance> GetAttendanceFromData(Attendance attendance);
    Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, string groupNumber);
    Task<LessonAttendanceInfo> GetInfoAttendanceByDate(Guid lessonId, string groupNumber, DateTimeOffset date);
}