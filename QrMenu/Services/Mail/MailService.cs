using System.Net;
using System.Net.Mail;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Mail;

namespace QrMenu.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool>SendEmailAsync(string toEmail, string subject, string body)
        {
            var mailConfig = new MailConfig();
            configuration.GetSection("MailConfig").Bind(mailConfig);

            using var client = new SmtpClient(mailConfig.Host, mailConfig.Port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mailConfig.Username, mailConfig.Password);
            client.EnableSsl = true;

            using var message = new MailMessage(mailConfig.Username, toEmail, subject, body);
            message.IsBodyHtml = true;
            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            return true;
        }
    }

}

