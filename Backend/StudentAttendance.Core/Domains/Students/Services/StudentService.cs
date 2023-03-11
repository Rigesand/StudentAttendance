using StudentAttendance.Core.Domains.Groups.Repositories;
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
        student.GroupId = await _groupRepository.GetIdByGroupNumber(student.GroupNumber);
        await _repository.CreateStudent(student);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateUser(Student updateStudent)
    {
        updateStudent.GroupId = await _groupRepository.GetIdByGroupNumber(updateStudent.GroupNumber);
        await _repository.UpdateUser(updateStudent);
        await _unitOfWork.SaveChanges();
    }

    public async Task Delete(Student student)
    {
        await _repository.Delete(student);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Student>> GetStudentsByGroup(int groupNumber)
    {
        var group = await _groupRepository.GetByGroupNumber(groupNumber);
        return group.Students!.OrderBy(it => it.Name).ToList();
    }
}