using FlightPlaner_ASPNET.Models;
using FlightPlaner_ASPNET.PropertyValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Route("api")]
public class CustomerApiController : BaseApiController
{
    public CustomerApiController(FlightPlanerDbContext context) : base(context)
    {
    }

    [HttpGet]
    [Route("airports")]
    public IActionResult SearchAirports(string search)
    {
        var cleanedSearch = InputValidation.ToLowerAndTrim(search);

        var airport = _context.Airports.Where
            (a => a.City.ToLower().Contains(cleanedSearch)
                || a.Country.ToLower().Contains(cleanedSearch)
                || a.AirportCode.ToLower().Contains(cleanedSearch));

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
        if (!InputValidation.IsSearchFlightValid(search))
        {
            return BadRequest();
        }

        var result = new PageResult() { Page=0, TotalItems=0 };
        
        result.Items = _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .AsEnumerable()
                .Where(f => f.From.AirportCode == search.From &&
                            f.To.AirportCode == search.To &&
                            Convert.ToDateTime(f.DepartureTime) > Convert.ToDateTime(search.DepartureDate)).ToList();
        
        result.TotalItems = result.Items.Count;

        return Ok(result);
    }

    [HttpGet]
    [Route("flights/{id}")]
    public IActionResult GetFlightById(int id)
    {
        var flight = FlightInContext(id);
        if (flight == null)
        {
            return NotFound();
        }

        return Ok(flight);
    }
}