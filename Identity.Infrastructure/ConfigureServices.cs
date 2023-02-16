using Identity.Application.Common.Abstractions;
using Identity.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());

        return services;
    }
}