using ApplicationService.Service.Requests;
using ApplicationService.Service.Requests.ErrorRequests;
using Core.Models;
using Core.Resources.Logging;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace ApplicationService.BotClient;

public class BotClientService : BackgroundService
{
    private readonly IMediator _mediator;
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<BotClientService> _logger;
    private readonly Dictionary<string, string> _botConfigs;

    public BotClientService(ILogger<BotClientService> logger, IOptions<BotConfig> botOptions, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        _botConfigs = botOptions.Value.Configs;
        _botClient = new TelegramBotClient(_botConfigs["API_KEY"]);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(LogMessages.START_BOT_SERVICE);

            // Receive all update types
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = [],
                ThrowPendingUpdates = Convert.ToBoolean(_botConfigs["ThrowPendingUpdates"])
            };

            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken
            );
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
        }
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) => await _mediator.Send(new UpdateRequest() { Update = update, BotClient = botClient }, cancellationToken);

    private async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) => await _mediator.Send(new ErrorRequest() { Exception = exception }, cancellationToken);
}