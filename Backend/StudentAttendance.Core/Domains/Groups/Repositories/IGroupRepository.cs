namespace StudentAttendance.Core.Domains.Groups.Repositories;

public interface IGroupRepository
{
    Task CreateGroup(string groupNumber);
    Task DeleteGroup(string groupNumber);
    Task<Guid> GetIdByGroupNumber(string groupNumber);
    Task<Group> GetByGroupNumber(string groupNumber);
    Task<IEnumerable<Group>> GetAllGroups();
}