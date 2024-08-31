using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("Lexi/api/v{version:apiVersion}")]
public class LexiServiceController : ControllerBase
{
    [HttpGet("SayHi")]
    public async Task<IActionResult> SayHiAsync(CancellationToken cancellationToken = default)
    {
        return Ok("Hi!");
    }
}