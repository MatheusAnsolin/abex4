using Microsoft.AspNetCore.Mvc;

namespace SiteBrecho.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class HealthCheckController : ControllerBase
{
    [HttpGet] 
    public IActionResult Get()
    {
        return Ok(new { Status = "API está no ar!", Timestamp = DateTime.UtcNow });
    }
}