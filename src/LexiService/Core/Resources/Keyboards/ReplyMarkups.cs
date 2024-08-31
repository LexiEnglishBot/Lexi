using System.Resources;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Resources.Keyboards;

public class ReplyMarkups
{
    public Dictionary<string, IReplyMarkup> ReplyMarkupsDictionary;

    public ReplyMarkups(ResourceManager keyboardResourceManager, ResourceManager keyboardDataResourceManager)
    {
        ReplyMarkupsDictionary = new Dictionary<string, IReplyMarkup>()
        {
            {
                nameof(KeyboardContents.BACK_KEY)
                , new ReplyKeyboardMarkup(new KeyboardButton(KeyboardContents.BACK_KEY))
            },
            {
                nameof(KeyboardContents.USER_IS_NOT_IN_CHANNEL)
                , new ReplyKeyboardMarkup(new KeyboardButton(KeyboardContents.USER_IS_NOT_IN_CHANNEL))
            },
        };
    }
}