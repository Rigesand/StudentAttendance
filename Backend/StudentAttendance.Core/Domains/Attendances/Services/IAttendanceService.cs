namespace StudentAttendance.Core.Domains.Attendances.Services;

public interface IAttendanceService
{
    Task Add(Attendance attendance);
    Task<Attendance> GetAttendanceFromData(Attendance attendance);
    Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, Guid groupId);

    Task<IEnumerable<LessonAttendanceInfo>> GetLessonsInfo(Guid lessonId, Guid groupId,
        DateTimeOffset begin, DateTimeOffset end);
}