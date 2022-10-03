using AutoMapper;
using StudentAttendance.Core.Domains.Attendances;
using StudentAttendance.Core.Domains.RefreshTokens;
using StudentAttendance.Core.Domains.Roles;
using StudentAttendance.Core.Domains.Users;
using StudentAttendance.Core.Domains.VisitedStudents;
using StudentAttendance.Data.Entities.Attendances;
using StudentAttendance.Data.Entities.RefreshTokens;
using StudentAttendance.Data.Entities.Roles;
using StudentAttendance.Data.Entities.Users;
using StudentAttendance.Data.Entities.VisitedStudents;

namespace StudentAttendance.Data;

public class DataMappingProfile : Profile
{
    public DataMappingProfile()
    {
        CreateMap<Attendance, AttendanceDbModel>()
            .ForMember(dest => dest.VisitedStudents,
                opt => opt
                    .MapFrom(it => it.VisitedStudents))
            .ReverseMap();

        CreateMap<VisitedStudentDbModel, VisitedStudent>()
            .ForMember(dest => dest.Id,
                opt => opt
                    .MapFrom(it => it.StudentId))
            .ReverseMap();

        CreateMap<RefreshToken, RefreshTokenDbModel>().ReverseMap();

        CreateMap<User, UserDbModel>()
            .ForMember(dest => dest.Role,
                opt => opt.MapFrom(it => it.Role))
            .ReverseMap();

        CreateMap<RoleDbModel, Role>().ReverseMap();
    }
}