using StudentAttendance.Data.Entities.Attendances;
using StudentAttendance.Data.Entities.Students;

namespace StudentAttendance.Data.Entities.Groups;

public class GroupDbModel
{
    public Guid Id { get; set; }
    public int GroupNumber { get; set; }
    public ICollection<StudentDbModel>? Students { get; set; }
    public ICollection<AttendanceDbModel>? Attendances { get; set; }
}