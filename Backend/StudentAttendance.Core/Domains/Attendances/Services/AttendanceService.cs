using StudentAttendance.Core.Domains.Attendances.Repositories;

namespace StudentAttendance.Core.Domains.Attendances.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AttendanceService(IAttendanceRepository attendanceRepository, IUnitOfWork unitOfWork)
    {
        _attendanceRepository = attendanceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(Attendance attendance)
    {
        await _attendanceRepository.Add(attendance);
        await _unitOfWork.SaveChanges();
    }

    public async Task<Attendance> GetAttendanceFromData(Attendance attendance)
    {
        return await _attendanceRepository.GetAttendanceFromData(attendance);
    }

    public async Task<LessonAttendanceInfo> GetAttendance(Guid lessonId, string groupNumber)
    {
        return await _attendanceRepository.GetAttendance(lessonId, groupNumber);
    }


    public async Task<IEnumerable<LessonInfoWithDate>> GetLessonsInfo(Guid lessonId, string groupNumber,
        DateTimeOffset begin, DateTimeOffset end)
    {
        var attendanceInfo = new List<LessonInfoWithDate>();
        while (begin.Date <= end.Date)
        {
            var info = await _attendanceRepository.GetInfoAttendanceByDate(lessonId, groupNumber, begin);
            if (info.Absence != 0 && info.Visited != 0)
            {
                attendanceInfo.Add(info);
            }

            begin = begin.Date.AddDays(1);
        }

        return attendanceInfo;
    }

    public async Task<LessonAttendanceInfo> GetAttendanceByStudent(Guid studentId, Guid lessonId, string groupNumber)
    {
        return await _attendanceRepository.GetAttendanceByStudent(studentId, lessonId, groupNumber);
    }

    public async Task<IEnumerable<DateTimeOffset>> GetAbsenceList(Guid lessonId, Guid studentId, string groupNumber)
    {
        return await _attendanceRepository.GetAbsenceList(lessonId, studentId, groupNumber);
    }
}