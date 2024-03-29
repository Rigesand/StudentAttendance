﻿using AutoMapper;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Groups;
using StudentAttendance.Core.Domains.Lessons;
using StudentAttendance.Core.Domains.Roles;
using StudentAttendance.Core.Domains.Students;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Data.Entities.Attendances;
using StudentAttendance.Data.Entities.Groups;
using StudentAttendance.Data.Entities.Lessons;
using StudentAttendance.Data.Entities.Roles;
using StudentAttendance.Data.Entities.Students;
using StudentAttendance.Data.Entities.Users;

namespace StudentAttendance.Data;

public class DataMappingProfile : Profile
{
    public DataMappingProfile()
    {
        CreateMap<User, UserDb>().ReverseMap();
        CreateMap<Role, RoleDb>().ReverseMap();

        CreateMap<Student, StudentDb>().ReverseMap();
        CreateMap<Group, GroupDb>().ReverseMap();

        CreateMap<Lesson, LessonDb>().ReverseMap();

        CreateMap<Attendance, AttendanceDb>().ReverseMap();
        CreateMap<AttendingLesson, AttendingLessonDb>().ReverseMap();
    }
}