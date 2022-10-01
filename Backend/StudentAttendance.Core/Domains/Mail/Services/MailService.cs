using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using StudentAttendance.Core.Domains.Users;

namespace StudentAttendance.Core.Domains.Mail.Services;

public class MailService : IMailService
{
    private readonly string _email;
    private readonly string _password;

    public MailService(IConfiguration configuration)
    {
        _email = configuration["SecretSettings:Email"];
        _password = configuration["SecretSettings:Password"];
    }
    public async Task<bool> Send(User user, string password)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Администрация сайта", _email));
        emailMessage.To.Add(new MailboxAddress("Oleg", user.Email));
        emailMessage.Subject = "Логин и пароль от учётной записи";
        emailMessage.Body = new TextPart("Plain")
        {
            Text =  $"Ваш логин и пароль от учетной записи: \n" +
                    $"Логин: {user.Email}\n" +
                    $"Пароль: {password}"
        };
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.mail.ru", 465, true);
            await client.AuthenticateAsync(_email, _password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
        return true;
    }
}