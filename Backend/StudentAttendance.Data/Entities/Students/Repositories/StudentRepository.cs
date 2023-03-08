using AutoMapper;
using StudentAttendance.Core.Domains.Students;
using StudentAttendance.Core.Domains.Students.Repositories;

namespace StudentAttendance.Data.Entities.Students.Repositories;

public class StudentRepository: IStudentRepository
{
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;

    public StudentRepository(StudentAttendanceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateStudent(Student student)
    {
        var dbStudent = _mapper.Map<StudentDb>(student);
        await _context.Students.AddAsync(dbStudent);
    }
}