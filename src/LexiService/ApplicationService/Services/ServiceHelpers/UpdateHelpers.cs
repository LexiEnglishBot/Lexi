
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ApplicationService.Services.ServiceHelpers;

public static class UpdateHelpers
{
    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Only process Message updates
        if (update.Message is not { } message)
        {
            return;
        }

        // Only process text messages
        if (message.Text is not { } messageText)
        {
            return;
        }

        Console.WriteLine($"Received a '{messageText}' message in chat {message.Chat.Id}.");
    }
}