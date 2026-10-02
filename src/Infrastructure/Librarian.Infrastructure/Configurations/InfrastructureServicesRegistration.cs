using Librarian.Application.Contracts.Email;
using Librarian.Application.Models.Email;
using Librarian.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Librarian.Infrastructure.Configurations;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailConfiguration>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, SmtpEmailSender>();
        return services;
    }
}
