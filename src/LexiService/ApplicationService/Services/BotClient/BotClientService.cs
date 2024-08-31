using Core.Resources.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace ApplicationService.Services.BotClient;

public partial class BotClientService : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<BotClientService> _logger;
    private readonly Dictionary<string, string> _botConfigs;

    public BotClientService(IConfiguration configuration, ILogger<BotClientService> logger)
    {
        _logger = logger;

        _botClient = new TelegramBotClient(configuration.GetSection("API_KEY").Value!);

        _botConfigs = configuration.GetSection("BotConfigs").GetChildren().ToDictionary(x => x.Key, x => x.Value)!;
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
}