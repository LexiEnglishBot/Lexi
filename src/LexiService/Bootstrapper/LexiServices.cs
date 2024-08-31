using ApplicationService.Services.BotClient;
using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Requests;

namespace Bootstrapper;

public static class LexiServices
{
    public static IServiceCollection RegisterTelegramServices(this IServiceCollection services)
    {
        return services.AddHostedService<BotClientService>();
    }
}