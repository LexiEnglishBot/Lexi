using ApplicationService.Services.BotManager;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Services.BotClient;

public partial class BotClientService : BackgroundService
{
    private readonly IBotAggregateManager _botAggregateManager;
    private readonly ILogger<BotClientService> _logger;

    public BotClientService(IBotAggregateManager botAggregateManager, ILogger<BotClientService> logger)
    {
        _botAggregateManager = botAggregateManager;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (!_botAggregateManager.TryGetBotAsync(out var botAggregate)) return;

            // Start Receiving Updates
            botAggregate.StartReceiving(cancellationToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
        }
    }
}