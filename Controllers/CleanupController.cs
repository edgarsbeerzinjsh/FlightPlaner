using FlightPlaner_ASPNET.Storage;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Route("testing-api")]
public class CleanupController : ControllerBase
{
    [HttpPost]
    [Route("clear")]
    public IActionResult Clear()
    {
        FlightStorage.Clear();
        return Ok();
    }
}