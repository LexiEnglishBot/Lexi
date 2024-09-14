using ApplicationService.Service.Requests.ErrorRequests;
using Core.Models;
using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot.Exceptions;

namespace ApplicationService.Service.Handlers.ErrorHandlers;

public class ErrorHandler : BaseRequestHandler, IRequestHandler<ErrorRequest, Result>
{
    public ErrorHandler(ILogger<BaseRequestHandler> logger, IOptions<BotConfig> botOptions, IServiceScopeFactory serviceScopeFactory) : base(logger, botOptions, serviceScopeFactory)
    {
    }

    public async Task<Result> Handle(ErrorRequest request, CancellationToken cancellationToken)
    {
        var exception = request.Exception;
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Logger.LogError(errorMessage);
        return Result.Ok();
    }
}