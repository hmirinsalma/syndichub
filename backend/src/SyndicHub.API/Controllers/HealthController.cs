using Microsoft.AspNetCore.Mvc;
using SyndicHub.Shared.Models;

namespace SyndicHub.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var healthData = new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Service = "SyndicHub API",
            Version = "1.0.0"
        };

        return Ok(ApiResponse<object>.SuccessResponse(
            healthData,
            "API is running successfully"
        ));
    }
}
