using Core.Exceptions;
using Domain.Bot.Aggregate;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Services.BotManager;

public class BotAggregateManager : IBotAggregateManager
{
    private readonly string _apiKey;
    private readonly BotAggregate _botAggregate;
    private readonly IValidator<BotAggregate> _validator;

    public BotAggregateManager(IConfiguration configuration, IValidator<BotAggregate> validator, ILogger<BotAggregate> logger)
    {
        _apiKey = configuration.GetSection("API_KEY").Value!;
        _botAggregate = new BotAggregate(_apiKey, logger);
        _validator = validator;

        var validationResult = _validator.Validate(_botAggregate);
        if (!validationResult.IsValid)
            throw new AppException(validationResult.Errors.First().ErrorMessage);
    }

    public bool TryGetBotAsync(out BotAggregate botAggregate)
    {
        botAggregate = _botAggregate;
        return botAggregate != null;
    }
}