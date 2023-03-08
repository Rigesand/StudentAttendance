namespace StudentAttendance.Core.Domains.Groups.Repositories;

public interface IGroupRepository
{
    Task CreateGroup(int? groupNumber);
    Task<Group> GetByGroupNumber(int groupNumber);
}