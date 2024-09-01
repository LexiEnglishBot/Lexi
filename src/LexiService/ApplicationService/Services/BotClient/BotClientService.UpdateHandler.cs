using Core.Resources.Commands;
using Core.Resources.Logging;
using Core.Resources.Messages;
using Core.Resources.ReplyMarkup;
using DataAccess.User;
using Domain.User.Aggregate;
using FluentResults;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ApplicationService.Services.BotClient;

public partial class BotClientService
{
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        _userRepository = ((IUserRepository?)_serviceScope.ServiceProvider.GetService(typeof(IUserRepository)))!;

        // Only process Message updates
        if (update.Message is not { } message) return;

        if (_botConfigs["ChannelLock"].Equals("Enable"))
        {
            var chatMember = await botClient.GetChatMemberAsync(new ChatId(_botConfigs["Channel"]), message.From.Id, cancellationToken);
            if (chatMember.Status is ChatMemberStatus.Left or ChatMemberStatus.Kicked or ChatMemberStatus.Restricted)
                await botClient.SendTextMessageAsync(message.Chat, MessageContents.USER_IS_NOT_IN_CHANNEL, replyMarkup: ReplyMarkups.ReplyMarkupsDictionary[ReplyMarkupContents.USER_IS_NOT_IN_CHANNEL], cancellationToken: cancellationToken);
        }

        if (message.Text is not { } text) return;


        var user = await InsertOrUpdateUser(message.From.Id, message.From.FirstName, message.From.LastName, message.From.Username, message.From.LanguageCode);
        if (user.IsFailed) return;
        if (user.Value.IsNewUser)
        {
            await SendWelcomeMessageToUser(user.Value.UserId, cancellationToken);
        }
        else if (text.Equals(BotCommands.START, StringComparison.OrdinalIgnoreCase) || text.Equals(ReplyMarkupContents.BACK_KEY, StringComparison.OrdinalIgnoreCase))
        {
            await SendHomeMessageToUser(user.Value.UserId, cancellationToken);
        }

        user.Value.IsNewUser = false;
        await _userRepository.SaveChangesAsync();

        _logger.LogDebug(LogMessages.MESSAGE_RECEIEVED, message.Text ?? string.Empty, message.Chat.Id);
    }

    private async Task<Result<UserAggregate>> InsertOrUpdateUser(long userId, string firstName, string? lastName, string? username, string? languageCode)
    {
        UserAggregate userAggregate;
        var userAggregateResult = await _userRepository.GetUserAsync(userId);
        if (userAggregateResult.IsFailed)
        {
            userAggregate = new UserAggregate(userId, firstName, lastName, username, languageCode);
            await _userRepository.AddUserAsync(userAggregate);
        }
        else
        {
            userAggregate = userAggregateResult.Value;
            await _userRepository.UpdateUserAsync(userAggregate);
        }
        return Result.Ok(userAggregate);
    }

    private async Task SendWelcomeMessageToUser(long userId, CancellationToken cancellationToken)
    {
        await _botClient.SendTextMessageAsync(new ChatId(userId), MessageContents.WELCOME, parseMode: ParseMode.Html, cancellationToken: cancellationToken);
    }

    private async Task SendHomeMessageToUser(long userId, CancellationToken cancellationToken)
    {
        await _botClient.SendTextMessageAsync(new ChatId(userId), MessageContents.HOME, parseMode: ParseMode.Html, cancellationToken: cancellationToken);
    }
}