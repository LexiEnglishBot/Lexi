using Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper.ExternalServices;

public static class ConfigServices
{
    public static IServiceCollection RegisterConfigs(this IServiceCollection services, IConfiguration configuration)
    {
        return services.Configure<BotConfig>(configuration.GetSection(nameof(BotConfig)));
    }
}