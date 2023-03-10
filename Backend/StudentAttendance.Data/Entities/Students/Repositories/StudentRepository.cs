using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task UpdateUser(Student updateStudent)
    {
        var dbStudent =await _context.Students.FirstOrDefaultAsync(it => it.Id == updateStudent.Id);
        dbStudent.Email = updateStudent.Email;
        dbStudent.Name = updateStudent.Name;
    }

    public async Task Delete(Student student)
    {
        var dbStudent = await _context.Students.FirstOrDefaultAsync(it => it.Name == student.Name);
        if (dbStudent == null)
        {
            throw new Exception("Такого пользователя не существует");
        }

        _context.Students.Remove(dbStudent);
    }
}