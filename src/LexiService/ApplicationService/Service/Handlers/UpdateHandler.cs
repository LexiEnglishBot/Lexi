using ApplicationService.Service.Requests;
using Core.Helpers;
using Core.Models;
using Core.Resources.Messages;
using Core.Resources.ReplyMarkup;
using Domain.User.Aggregate;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ApplicationService.Service.Handlers;

public sealed class UpdateHandler : BaseRequestHandler, IRequestHandler<UpdateRequest>
{
    public UpdateHandler(ILogger<BaseRequestHandler> logger, IOptions<BotConfig> botOptions, IServiceScopeFactory serviceScopeFactory) : base(logger, botOptions, serviceScopeFactory)
    {
    }

    public async Task Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var bot = request.BotClient;
            var update = request.Update;

            var message = update.Message;
            if (message == null) return;

            #region [- User Subscription -]
            if (Convert.ToBoolean(BotConfigs["ChannelLockEnable"]) && await CheckUserSubscription(bot, message.From.Id, cancellationToken))
            {
                await bot.SendTextMessageAsync(
                    chatId: message.From.Id,
                    text: MessageContents.USER_IS_NOT_IN_CHANNEL,
                    replyMarkup: ReplyMarkups.ReplyMarkupsDictionary[ReplyMarkupContents.USER_IS_NOT_IN_CHANNEL],
                    cancellationToken: cancellationToken);
                return;
            }
            #endregion

            #region [- User Aggregate -]
            if (!_userRepository.TryGetUserAggregate(message.From.Id, out var user))
            {
                user = new UserAggregate(
                    message.From.Id,
                    message.From.FirstName,
                    message.From.LastName,
                    message.From.Username,
                    message.From.LanguageCode);

                await _userRepository.AddUserAsync(user);
            }
            #endregion

            var text = message.Text;
            if (text == null) return;

            if (text.Equals(["/start", "back"]))
            {
                await bot.SendTextMessageAsync(
                    chatId: user.UserId,
                    text: MessageContents.HOME,
                    replyMarkup: new ReplyKeyboardMarkup(new KeyboardButton("🕹 Mini Games 🕹")),
                    cancellationToken: cancellationToken);
                return;
            }

            #region [- Mini Games -]
            if (text.Equals("🕹 Mini Games 🕹", StringComparison.OrdinalIgnoreCase))
            {
                await bot.SendTextMessageAsync(
                    chatId: user.UserId,
                    text: MessageContents.SELECT_GAME,
                    replyMarkup: new ReplyKeyboardMarkup(
                    [
                        ["Dart", "Dice"],
                    ["Basketball", "Football"],
                    ["back"],
                    ]),
                    cancellationToken: cancellationToken);
                return;
            }
            if (text.Equals("Dart", StringComparison.OrdinalIgnoreCase))
            {
                await bot.SendDiceAsync(
                   chatId: user.UserId,
                   emoji: Emoji.Darts,
                   cancellationToken: cancellationToken);
                return;
            }
            if (text.Equals("Dice", StringComparison.OrdinalIgnoreCase))
            {
                await bot.SendDiceAsync(
                    chatId: user.UserId,
                    emoji: Emoji.Dice,
                    cancellationToken: cancellationToken);
                return;
            }
            if (text.Equals("Basketball", StringComparison.OrdinalIgnoreCase))
            {
                await bot.SendDiceAsync(
                    chatId: user.UserId,
                    emoji: Emoji.Basketball,
                    cancellationToken: cancellationToken);
                return;
            }
            if (text.Equals("Football", StringComparison.OrdinalIgnoreCase))
            {
                await bot.SendDiceAsync(
                    chatId: user.UserId,
                    emoji: Emoji.Football,
                    cancellationToken: cancellationToken);
                return;
            }
            #endregion

            #region [- User Save Changes -]
            await _userRepository.SaveChangesAsync(cancellationToken);
            #endregion
        }
        catch (Exception exception)
        {
            await request.BotClient.SendTextMessageAsync(long.Parse(BotConfigs["AdminId"]), exception.Message, cancellationToken: cancellationToken);
        }
    }

    private async Task<bool> CheckUserSubscription(ITelegramBotClient bot, long fromId, CancellationToken cancellationToken = default)
    {
        var chatMember = await bot.GetChatMemberAsync(new ChatId(BotConfigs["Channel"]), fromId, cancellationToken);
        return chatMember.Status is ChatMemberStatus.Left or ChatMemberStatus.Kicked or ChatMemberStatus.Restricted;
    }
}