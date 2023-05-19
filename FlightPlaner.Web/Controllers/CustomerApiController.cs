using AutoMapper;
using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using FlightPlaner.Core.Validations;
using FlightPlaner_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Route("api")]
public class CustomerApiController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFlightService _flightService;
    private readonly IAirportService _airportService;
    private readonly IEnumerable<IValidateSearchFlight> _validators;
    public CustomerApiController(
        IFlightService flightService,
        IAirportService airportService,
        IMapper mapper,
        IEnumerable<IValidateSearchFlight> validators)
    {
        _mapper = mapper;
        _flightService = flightService;
        _airportService = airportService;
        _validators = validators;
    }

    [HttpGet]
    [Route("airports")]
    public IActionResult SearchAirports(string search)
    {
        var airport = _airportService.GetSearchAirports(search);

        if (airport == null)
        {
            return NotFound();
        }
        
        return Ok(_mapper.Map<List<AddAirportRequest>>(airport));
    }

    [HttpPost]
    [Route("flights/search")]
    public IActionResult SearchFlights(FlightSearchQuery search)
    {
        if (!_validators.All(v => v.IsValid(search)))
        {
            return BadRequest();
        }

        return Ok(_flightService.SearchFlights(search));
    }

    [HttpGet]
    [Route("flights/{id}")]
    public IActionResult GetFlightById(int id)
    {
        var flight = _flightService.GetFullFlight(id);
        if (flight == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<AddFlightRequest>(flight));
    }
}