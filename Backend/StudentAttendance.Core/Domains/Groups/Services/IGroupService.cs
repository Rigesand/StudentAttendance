namespace StudentAttendance.Core.Domains.Groups.Services;

public interface IGroupService
{
    Task CreateGroup(int groupNumber);
}