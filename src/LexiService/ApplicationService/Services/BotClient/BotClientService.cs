using Core.Resources.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace ApplicationService.Services.BotClient;

public partial class BotClientService : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<BotClientService> _logger;

    public BotClientService(IConfiguration configuration, ILogger<BotClientService> logger)
    {
        _logger = logger;

        var apiKey = configuration.GetSection("API_KEY").Value!;
        _botClient = new TelegramBotClient(apiKey);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(LogMessages.START_BOT_SERVICE);

            // Receive all update types
            var receiverOptions = new ReceiverOptions { AllowedUpdates = [] };

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


    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Only process Message updates
        if (update.Message is not { } message) return;

        // Only process text messages
        if (message.Text is not { } messageText) return;

        _logger.LogError(LogMessages.START_BOT_SERVICE, messageText, message.Chat.Id);
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        _logger.LogError(errorMessage);
        return Task.CompletedTask;
    }
}