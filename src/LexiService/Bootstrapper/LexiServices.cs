using ApplicationService.Services.BotClient;
using DataAccess.User;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper;

public static class LexiServices
{
    public static IServiceCollection RegisterTelegramServices(this IServiceCollection services)
    {
        return services.AddHostedService<BotClientService>();
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IUserRepository, UserRepository>();
    }
}