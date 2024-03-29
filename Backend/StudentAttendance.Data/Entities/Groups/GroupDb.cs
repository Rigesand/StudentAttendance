﻿using StudentAttendance.Data.Entities.Attendances;
using StudentAttendance.Data.Entities.Students;

namespace StudentAttendance.Data.Entities.Groups;

public class GroupDb
{
    public Guid Id { get; set; }
    public string GroupNumber { get; set; }
    public ICollection<StudentDb>? Students { get; set; }
    public ICollection<AttendanceDb>? Attendances { get; set; }
}