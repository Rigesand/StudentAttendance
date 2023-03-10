using AutoMapper;
using StudentAttendance.Api.Controllers.Authorizations.Dto;
using StudentAttendance.Api.Controllers.Students.Dto;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Core.Domains.Students;
using StudentAttendance.Core.Domains.Tokens;
using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Api;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<TokenModel, TokenResponse>();

        CreateMap<UserRequest, User>().ReverseMap();
        CreateMap<UserResponse, User>().ReverseMap();

        CreateMap<StudentResponse, Student>().ReverseMap();
        CreateMap<StudentRequest, Student>().ReverseMap();
    }
}