using FlightPlaner_ASPNET.Storage;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Route("api")]
public class CustomerApiController : ControllerBase
{
    [HttpGet]
    [Route("airports")]
    public IActionResult SearchAirport(string search)
    {
        var airport = AirportStorage.SearchAirport(search);
        if (airport == null)
        {
            return NotFound();
        }
        
        return Ok(airport);
    }
}