namespace StudentAttendance.Core.Domains.Groups.Services;

public interface IGroupService
{
    Task CreateGroup(int groupNumber);
    Task DeleteGroup(int groupNumber);
}