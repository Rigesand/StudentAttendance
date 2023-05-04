namespace StudentAttendance.Core.Domains.Attendances.Repostories;

public interface IAttendanceRepository
{
    Task Add(Attendance attendance);
    Task<Attendance> GetAttendanceFromData(Attendance attendance);
    Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, Guid groupId);
}