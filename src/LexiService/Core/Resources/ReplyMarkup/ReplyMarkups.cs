using System.Resources;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Resources.ReplyMarkup;

public static class ReplyMarkups
{
    public static Dictionary<string, IReplyMarkup> ReplyMarkupsDictionary = new Dictionary<string, IReplyMarkup>()
    {
        {
            nameof(ReplyMarkupContents.BACK_KEY)
            , new ReplyKeyboardMarkup(new KeyboardButton(ReplyMarkupContents.BACK_KEY))
        },
        {
            nameof(ReplyMarkupContents.USER_IS_NOT_IN_CHANNEL)
            , new ReplyKeyboardMarkup(new KeyboardButton(ReplyMarkupContents.USER_IS_NOT_IN_CHANNEL))
        },
    };
}