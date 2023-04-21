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
    private static readonly object flightsLock = new object();
    private static readonly ReaderWriterLockSlim airportLock = new ReaderWriterLockSlim();
    
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
        lock (flightsLock)
        {
            if (!FlightStorage.IsAllFlightFieldsCorrect(flight))
            {
                return BadRequest();
            }

            if (FlightStorage.IsAlreadyInFlights(flight))
            {
                return Conflict();
            }
            
            airportLock.EnterWriteLock();
            try
            {
                FlightStorage.AddFlight(flight);
                AirportStorage.AddAirport(flight.From);
                AirportStorage.AddAirport(flight.To);
            }
            finally
            {
                airportLock.ExitWriteLock();
            }
            return Created("", flight);
        }
    }

    [HttpDelete]
    [Route("flights/{id}")]
    public IActionResult DeleteFlight(int id)
    {
        lock (flightsLock)
        {
            FlightStorage.DeleteFlight(id);
            return Ok();
        }
    }
}