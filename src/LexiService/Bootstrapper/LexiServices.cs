using ApplicationService.Services.BotClient;
using ApplicationService.Services.BotClient.Requests;
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

    public static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendMessageRequest).Assembly));
        services.AddTransient<IRequestHandler<SendBotMessageRequest, Result>, BotClientHandler>();

        return services;
    }
}