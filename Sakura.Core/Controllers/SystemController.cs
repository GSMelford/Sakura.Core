using Microsoft.AspNetCore.Mvc;

namespace Sakura.Core.Controllers;

[ApiController]
public class SystemController : Controller
{
    private readonly ILogger<SystemController> _logger;
    
    public SystemController(ILogger<SystemController> logger)
    {
        _logger = logger;
    }

    [HttpGet("check")]
    public IActionResult CheckSystem()
    {
        _logger.LogInformation("The Sakura system works good");
        return Ok();
    }
}