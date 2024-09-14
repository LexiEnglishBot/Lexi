using Core.Models;
using DataAccess.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApplicationService.Service.Handlers;

public abstract class BaseRequestHandler
{
    protected readonly ILogger<BaseRequestHandler> Logger;
    protected readonly Dictionary<string, string> BotConfigs;
    protected readonly IUserRepository _userRepository;

    public BaseRequestHandler(ILogger<BaseRequestHandler> logger, IOptions<BotConfig> botOptions, IServiceScopeFactory serviceScopeFactory)
    {
        Logger = logger;
        BotConfigs = botOptions.Value.Configs;
        _userRepository = ((IUserRepository?)serviceScopeFactory.CreateScope().ServiceProvider.GetService(typeof(IUserRepository)))!;
    }
}