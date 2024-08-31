using ApplicationService.Services.BotClient.Requests;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace ApiServer.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("Lexi/api/v{version:apiVersion}")]
public class LexiController(IMediator mediator) : ControllerBase
{
    [HttpPost("SendTestMessage")]
    public async Task<IActionResult> SendTestMessageAsync(SendMessageRequestDto sendMessageRequest, CancellationToken cancellationToken = default)
    {
        var request = new SendBotMessageRequest(new ChatId(sendMessageRequest.ChatId), sendMessageRequest.Text);
        var result = await mediator.Send(request, cancellationToken);
        return (result as IActionResult)!;
    }
}