using System;

namespace Librarian.Application.Models.Email;

public class EmailConfiguration
{
    public string FromAddress { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string SmtpUsername { get; set; } = string.Empty;
    public string SmptPassword { get; set; } = string.Empty;
}
