namespace StudentAttendance.Core.Domains.Attendances;

public class LessonInfoWithDate: LessonAttendanceInfo
{
    public DateTimeOffset Date { get; set; }
}