namespace StudentAttendance.Core.Domains.Attendances.Repositories;

public interface IAttendanceRepository
{
    Task Add(Attendance attendance);
    Task<Attendance> GetAttendanceFromData(Attendance attendance);
    Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, string groupNumber);
    Task<LessonInfoWithDate> GetInfoAttendanceByDate(Guid lessonId, string groupNumber, DateTimeOffset date);
    Task<LessonAttendanceInfo> GetAttendanceByStudent(Guid studentId, Guid lessonId, string groupNumber);
    Task<IEnumerable<DateTimeOffset>> GetAbsenceList(Guid lessonId, Guid studentId, string groupNumber);
}