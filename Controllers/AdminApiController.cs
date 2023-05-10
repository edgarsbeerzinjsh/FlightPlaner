using FlightPlaner_ASPNET.Models;
using FlightPlaner_ASPNET.PropertyValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Authorize]
[Route("admin-api")]
public class AdminApiController : BaseApiController
{
    private static readonly object flightsLock = new object();
    private static readonly ReaderWriterLockSlim airportLock = new ReaderWriterLockSlim();

    public AdminApiController(FlightPlanerDbContext context) : base(context)
    {
    }
    
    [HttpGet]
    [Route("flights/{id}")]
    public IActionResult GetFlights(int id)
    {
        var flight = FlightInContext(id);

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
            if (!InputValidation.IsAllFlightFieldsCorrect(flight))
            {
                return BadRequest();
            }

            if (_context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .Any(f => f.DepartureTime == flight.DepartureTime
                            && f.ArrivalTime == flight.ArrivalTime
                            && f.Carrier == flight.Carrier
                            && f.From.City == flight.From.City
                            && f.From.Country == flight.From.Country
                            && f.From.AirportCode == flight.From.AirportCode
                            && f.To.City == flight.To.City
                            && f.To.Country == flight.To.Country
                            && f.To.AirportCode == flight.To.AirportCode))
            {
                return Conflict();
            }
            
            airportLock.EnterWriteLock();
            try
            {
                _context.Flights.Add(flight);
                _context.SaveChanges();
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
            var flight = FlightInContext(id);

            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.Airports.Remove(flight.From);
                _context.Airports.Remove(flight.To);
                _context.SaveChanges();
            }
            
            return Ok();
        }
    }
}