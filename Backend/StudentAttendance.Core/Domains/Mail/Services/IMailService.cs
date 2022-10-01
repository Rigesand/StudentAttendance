using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Core.Domains.Mail.Services;

public interface IMailService
{
    public Task<bool> Send(User user, string password);
}