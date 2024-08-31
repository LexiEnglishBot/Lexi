using FluentResults;
using MediatR;
using Telegram.Bot.Types;

namespace ApplicationService.Services.BotClient.Requests;

public class SendBotMessageRequest : IRequest<Result>
{
    public ChatId ChatId { get; set; }
    public string Text { get; set; }

    public SendBotMessageRequest(ChatId chatId, string text)
    {
        ChatId = chatId;
        Text = text;
    }
}

public class SendMessageRequestDto
{
    public long ChatId { get; set; }
    public string Text { get; set; }
}