﻿using StudentAttendance.Core.Domains.Groups.Repositories;
using StudentAttendance.Core.Domains.Students.Repositories;

namespace StudentAttendance.Core.Domains.Students.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IGroupRepository _groupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IStudentRepository repository, IUnitOfWork unitOfWork, IGroupRepository groupRepository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _groupRepository = groupRepository;
    }

    public async Task CreateStudent(Student student)
    {
        student.GroupDbModel = await _groupRepository.GetByGroupNumber(student.GroupNumber);
        await _repository.CreateStudent(student);
        await _unitOfWork.SaveChanges();
    }
}