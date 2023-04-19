using FlightPlaner_ASPNET.Models;
using FlightPlaner_ASPNET.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Authorize]
[Route("admin-api")]
public class AdminApiController : ControllerBase
{
    [HttpGet]
    [Route("flights/{id}")]
    public IActionResult GetFlights(int id)
    {
        var flight = FlightStorage.GetFlight(id);
        if (flight == null)
        {
            return NotFound();
        }

        return Ok(flight);
    }

    [HttpPut]
    [Route("flights")]
    public IActionResult AddFlight(Flight flight)
    {
        if (!FlightStorage.IsAllFieldsCorrect(flight))
        {
            return BadRequest();
        }
        
        if (FlightStorage.IsAlreadyInFlights(flight))
        {
            return Conflict();
        }
        
        FlightStorage.AddFlight(flight);
        return Created("", flight);
    }
}