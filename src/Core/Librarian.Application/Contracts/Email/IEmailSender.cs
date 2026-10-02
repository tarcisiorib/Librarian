using Librarian.Application.Models.Email;

namespace Librarian.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
