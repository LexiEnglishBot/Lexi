using ApplicationService.Services.BotClient.Requests;
using ApplicationService.Services.BotManager;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Services.BotClient;

public partial class BotClientHandler : IRequestHandler<SendBotMessageRequest, Result>
{
    private readonly IBotAggregateManager _botAggregateManager;
    private readonly ILogger<BotClientService> _logger;

    public BotClientHandler(IBotAggregateManager botAggregateManager, ILogger<BotClientService> logger)
    {
        _botAggregateManager = botAggregateManager;
        _logger = logger;
    }

    public async Task<Result> Handle(SendBotMessageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (!_botAggregateManager.TryGetBotAsync(out var botAggregate))
                return Result.Fail("Unable to get bot instance");

            botAggregate.SendMessage(request.ChatId, request.Text, cancellationToken: cancellationToken);
            return Result.Ok();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            return Result.Fail(exception.Message);
        }
    }
}