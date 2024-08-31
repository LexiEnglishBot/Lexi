using Core.Resources.Logging;
using Core.Resources.Messages;
using Core.Resources.ReplyMarkup;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ApplicationService.Services.BotClient;

public partial class BotClientService : BackgroundService
{
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Only process Message updates
        if (update.Message is not { } message) return;

        if (_botConfigs["ChannelLock"].Equals("Enable"))
        {
            var chatMember = await botClient.GetChatMemberAsync(new ChatId(_botConfigs["Channel"]), message.From.Id, cancellationToken);
            if (chatMember.Status is ChatMemberStatus.Left or ChatMemberStatus.Kicked or ChatMemberStatus.Restricted)
                await botClient.SendTextMessageAsync(message.Chat, MessageContents.USER_IS_NOT_IN_CHANNEL, replyMarkup: ReplyMarkups.ReplyMarkupsDictionary[ReplyMarkupContents.USER_IS_NOT_IN_CHANNEL], cancellationToken: cancellationToken);
        }

        // Only process text messages
        if (message.Text is not { } messageText) return;

        _logger.LogDebug(LogMessages.MESSAGE_RECEIEVED, messageText, message.Chat.Id);
    }
}