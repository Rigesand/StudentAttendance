using AutoMapper;
using StudentAttendance.Api.Controllers.Attendances.Dto;
using StudentAttendance.Api.Controllers.Tokens.Dto;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Api.Responses;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.JwtTokens;
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
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<TokenRequestDto, JwtTokens>().ReverseMap();

        CreateMap<AuthResponse, JwtTokens>()
            .ForMember(dest => dest.Errors,
                opt => opt
                    .MapFrom(it => it.Errors))
            .ReverseMap();
    }
}