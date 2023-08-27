using System;
namespace QrMenu.Services.Mail
{
    public interface IMailService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string body);
    }

}

