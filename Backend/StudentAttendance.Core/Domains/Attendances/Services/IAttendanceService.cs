namespace StudentAttendance.Core.Domains.Attendances.Services;

public interface IAttendanceService
{
    Task Add(Attendance attendance);
    Task<Attendance> GetAttendanceFromData(Attendance attendance);
    Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, string groupNumber);

    Task<IEnumerable<LessonInfoWithDate>> GetLessonsInfo(Guid lessonId, string groupNumber,
        DateTimeOffset begin, DateTimeOffset end);

    Task<LessonAttendanceInfo> GetAttendanceByStudent(Guid studentId, Guid lessonId, string groupNumber);
}