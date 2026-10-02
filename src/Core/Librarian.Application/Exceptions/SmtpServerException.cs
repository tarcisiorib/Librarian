using System;

namespace Librarian.Application.Exceptions;

public class SmtpServerException : Exception
{
    public SmtpServerException(Exception innerException, string email, string action)
        : base($"Failed to send the {action} email to {email}.", innerException)
    {
    }
}
