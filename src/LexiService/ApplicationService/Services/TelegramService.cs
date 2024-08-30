using Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace ApplicationService.Services;

public partial class TelegramService : BackgroundService
{
    private readonly TelegramBotClient _bot;

    public TelegramService(IConfiguration configuration)
    {
        var apiKey = configuration.GetSection("API_KEY").Value!;

        if (string.IsNullOrWhiteSpace(apiKey)) 
            throw new AppException("Invalid API_KEY!");

        _bot = new TelegramBotClient(apiKey);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = [] // receive all update types
        };

        _bot.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cancellationToken
        );
    }
}