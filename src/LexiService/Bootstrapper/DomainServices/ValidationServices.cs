using ApplicationService.Services.BotManager;
using Domain.Bot.Aggregate;
using Domain.Bot.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper.DomainServices;

public static class ValidationServices
{
    public static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        return services.AddSingleton<IValidator<BotAggregate>, BotValidator>();
    }

    public static IServiceCollection RegisterBotManager(this IServiceCollection services)
    {
        return services.AddSingleton<IBotAggregateManager, BotAggregateManager>();
    }
}