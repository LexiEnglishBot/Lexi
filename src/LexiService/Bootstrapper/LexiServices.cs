using ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper;

public static class LexiServices
{
    public static IServiceCollection RegisterTelegramServices(this IServiceCollection services)
    {
        return services.AddHostedService<TelegramService>();
    }
}