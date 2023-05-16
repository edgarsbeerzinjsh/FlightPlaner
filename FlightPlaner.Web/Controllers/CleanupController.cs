using FlightPlaner.Data;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Route("testing-api")]
public class CleanupController : BaseApiController
{
    public CleanupController(IFlightPlanerDbContext context) : base(context)
    {
    }

    [HttpPost]
    [Route("clear")]
    public IActionResult Clear()
    {
        _context.Flights.RemoveRange(_context.Flights);
        _context.Airports.RemoveRange(_context.Airports);
        _context.SaveChanges();

        return Ok();
    }
}