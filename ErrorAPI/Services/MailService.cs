using System.Net.Mail;
using System.Threading.Tasks;

namespace ErrorAPI.Services
{
    public class MailService
    {
        public async Task SendEmail(string subject, string body, string recipient)
        {
            var smtpClient = new SmtpClient();
            await smtpClient.SendMailAsync(new MailMessage
            {
                Body = body,
                To = {recipient},
                Subject = subject
            });
        }
    }
}