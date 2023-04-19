namespace StudentAttendance.Core.Domains.Groups.Services;

public interface IGroupService
{
    Task CreateGroup(string groupNumber);
    Task DeleteGroup(string groupNumber);
    Task<IEnumerable<Group>> GetAllGroup();
}