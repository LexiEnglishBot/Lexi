using System.Resources;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Resources.ReplyMarkup;

public class ReplyMarkups
{
    public Dictionary<string, IReplyMarkup> ReplyMarkupsDictionary;

    public ReplyMarkups(ResourceManager keyboardResourceManager, ResourceManager keyboardDataResourceManager)
    {
        ReplyMarkupsDictionary = new Dictionary<string, IReplyMarkup>()
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
}