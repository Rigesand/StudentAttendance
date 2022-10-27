using AutoMapper;
using StudentAttendance.Api.Controllers.Attendances.Dto;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.VisitedStudents;

namespace StudentAttendance.Api;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<AddAttendanceDto, Attendance>()
            .ForMember(dest => dest.VisitedStudents,
                opt => opt
                    .MapFrom(it => it.VisitedStudents))
            .ReverseMap();

        CreateMap<VisitedStudentDto, VisitedStudent>().ReverseMap();

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Role,
                opt => opt.MapFrom(it => it.RoleName));

        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.Role,
                opt => opt.Ignore());
    }
}