using FluentResults;
using MediatR;
using Telegram.Bot.Types;

namespace ApplicationService.Service.Requests.ErrorRequests;

public class ErrorRequest : IRequest<Result>          
{
    public required Exception Exception { get; set; }         
}           