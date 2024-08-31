using Domain.Bot.Aggregate;

namespace ApplicationService.Services.BotManager;

public interface IBotAggregateManager
{
    public bool TryGetBotAsync(out BotAggregate botAggregate);
}