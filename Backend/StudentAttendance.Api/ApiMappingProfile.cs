using AutoMapper;
using StudentAttendance.Api.Controllers.Attendances.Dto;
using StudentAttendance.Api.Controllers.Authorizations.Dto;
using StudentAttendance.Api.Controllers.Groups.Dto;
using StudentAttendance.Api.Controllers.Lessons.Dto;
using StudentAttendance.Api.Controllers.Profiles.Dto;
using StudentAttendance.Api.Controllers.Students.Dto;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Core;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Groups;
using StudentAttendance.Core.Domains.Lessons;
using StudentAttendance.Core.Domains.Students;
using StudentAttendance.Core.Domains.Tokens;
using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Api;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<TokenModel, TokenResponse>();

        CreateMap<UserRequest, User>()
            .ForMember(d => d.Role, m => m.MapFrom(s => "Студент"))
            .ReverseMap();
        CreateMap<UserResponse, User>().ReverseMap();
        CreateMap<ProfileRequest, User>()
            .ForMember(d => d.PasswordHash, m => m.MapFrom(s => HashService.GetHash(s.Password)))
            .ReverseMap();

        CreateMap<StudentResponse, Student>().ReverseMap();
        CreateMap<StudentRequest, Student>().ReverseMap();

        CreateMap<Group, GroupResponse>().ReverseMap();

        CreateMap<LessonRequest, Lesson>().ReverseMap();
        CreateMap<LessonResponse, Lesson>().ReverseMap();
        
        CreateMap<Attendance, AttendanceDto>().ReverseMap();
        CreateMap<Attendance, FilterDate>().ReverseMap();
        CreateMap<AttendingLesson, AttendingLessonDto>().ReverseMap();
        
    }
}