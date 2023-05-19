using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Route("testing-api")]
public class CleanupController : ControllerBase
{
    private readonly IDbService _context;
    public CleanupController(IDbService context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("clear")]
    public IActionResult Clear()
    {
            _context.DeleteAll<Flight>();
            _context.DeleteAll<Airport>();

            return Ok();
    }
}