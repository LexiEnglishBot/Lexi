using Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace ApplicationService.Services;

public class TelegramService : BackgroundService
{
    private readonly TelegramBotClient _bot;

    public TelegramService(IConfiguration configuration)
    {
        var apiKey = configuration.GetSection("API_KEY").Value!;
        if (string.IsNullOrWhiteSpace(apiKey)) throw new AppException("Invalid API_KEY!");

        _bot = new TelegramBotClient(apiKey);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var me = await _bot.GetMeAsync(cancellationToken);
        Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
    }
}