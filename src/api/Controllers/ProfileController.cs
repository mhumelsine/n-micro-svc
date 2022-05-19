using Microsoft.AspNetCore.Mvc;

namespace Profile.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public async Task<IActionResult> QueryProfiles()
    {
        return Ok(new object[]{});
    }
}
