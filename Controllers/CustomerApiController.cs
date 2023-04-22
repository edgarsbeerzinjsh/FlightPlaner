using FlightPlaner_ASPNET.Models;
using FlightPlaner_ASPNET.Storage;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Route("api")]
public class CustomerApiController : ControllerBase
{
    [HttpGet]
    [Route("airports")]
    public IActionResult SearchAirports(string search)
    {
        var airport = AirportStorage.SearchAirport(search);
        if (airport == null)
        {
            return NotFound();
        }
        
        return Ok(airport);
    }

    [HttpPost]
    [Route("flights/search")]
    public IActionResult SearchFlights(CustomerSearchQuery search)
    {
        if (!FlightStorage.IsSearchFlightValid(search))
        {
            return BadRequest();
        }
        var result = FlightStorage.SearchFlights(search);
        return Ok(result);
    }

    [HttpGet]
    [Route("flights/{id}")]
    public IActionResult GetFlightById(int id)
    {
        var flight = FlightStorage.GetFlight(id);
        if (flight == null)
        {
            return NotFound();
        }

        return Ok(flight);
    }
}