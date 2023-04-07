using StudentAttendance.Core.Domains.Groups.Repositories;

namespace StudentAttendance.Core.Domains.Groups.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GroupService(IGroupRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateGroup(string groupNumber)
    {
        await _repository.CreateGroup(groupNumber);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteGroup(string groupNumber)
    {
        await _repository.DeleteGroup(groupNumber);
        await _unitOfWork.SaveChanges();
    }
}