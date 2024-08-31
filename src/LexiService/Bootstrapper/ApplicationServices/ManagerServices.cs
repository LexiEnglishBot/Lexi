using ApplicationService.Services.BotManager;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper.ApplicationServices;

public static class ManagerServices
{
    public static IServiceCollection RegisterBotManager(this IServiceCollection services)
    {
        return services.AddSingleton<IBotAggregateManager, BotAggregateManager>();
    }
}