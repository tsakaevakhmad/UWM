using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using UWM.Domain.Options;
using UWM.BLL.Interfaces;

namespace UWM.BLL.Services
{
    public class MailSenderServices : IMailSenderServices
    {
        private readonly MailConfig _mailOptions;

        public MailSenderServices(IOptions<MailConfig> mailOptions)
        {
            _mailOptions = mailOptions.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("UWM", _mailOptions.Mail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_mailOptions.Domain, _mailOptions.Port, _mailOptions.SSL);
                await client.AuthenticateAsync(_mailOptions.Mail, _mailOptions.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
