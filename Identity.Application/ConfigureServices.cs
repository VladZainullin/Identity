using Microsoft.Extensions.DependencyInjection;
using static System.Reflection.Assembly;

namespace Identity.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(GetExecutingAssembly()));

        return services;
    }
}