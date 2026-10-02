using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Librarian.Application.Configurations;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        return services;
    }
}
