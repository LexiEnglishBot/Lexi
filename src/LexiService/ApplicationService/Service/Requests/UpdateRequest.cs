using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ApplicationService.Service.Requests;

public class UpdateRequest : IRequest
{
    public required Update Update { get; set; }
    public required ITelegramBotClient BotClient { get; set; }
}