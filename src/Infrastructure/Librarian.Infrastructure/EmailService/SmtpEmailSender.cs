using System.Net.Mail;
using Librarian.Application.Contracts.Email;
using Librarian.Application.Models.Email;
using Microsoft.Extensions.Options;

namespace Librarian.Infrastructure.EmailService;

public class SmtpEmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfiguration;

    public SmtpEmailSender(IOptions<EmailConfiguration> emailConfiguration)
    {
        _emailConfiguration = emailConfiguration.Value;
    }
    public async Task<bool> SendEmail(EmailMessage email)
    {
        using (var client = new SmtpClient())
        {
            var emailMessage = new MailMessage
            {
                From = new MailAddress(_emailConfiguration.FromAddress, _emailConfiguration.FromName),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true
            };

            emailMessage.To.Add(email.To);

            client.Host = _emailConfiguration.SmtpServer;
            client.Port = _emailConfiguration.SmtpPort;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(
                _emailConfiguration.SmtpUsername, _emailConfiguration.SmptPassword);
            client.EnableSsl = false;
            await client.SendMailAsync(emailMessage);
            return true;
        }
    }
}
