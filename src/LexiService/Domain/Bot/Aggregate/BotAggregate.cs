using Core.Resources.Logging;
using Domain.Bot.ValueObjects;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Domain.Bot.Aggregate;

public class BotAggregate : AggregateRoot
{
    public ApiKey Apikey { get; private set; }
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<BotAggregate> _logger;

    public BotAggregate(string apikey, ILogger<BotAggregate> logger) : base(Guid.NewGuid())
    {
        _logger = logger;

        Apikey = new ApiKey(apikey);
        _botClient = new TelegramBotClient(Apikey.Key);
    }

    public void StartReceiving(CancellationToken cancellationToken = default)
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

    public void SendMessage(ChatId chatId, string text, CancellationToken cancellationToken = default)
    {
        _botClient.SendTextMessageAsync(chatId, text, cancellationToken: cancellationToken);
    }
}