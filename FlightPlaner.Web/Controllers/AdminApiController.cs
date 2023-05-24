using AutoMapper;
using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using FlightPlaner.Core.Validations;
using FlightPlaner_ASPNET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlaner_ASPNET.Controllers;

[ApiController]
[Authorize]
[Route("admin-api")]
public class AdminApiController : ControllerBase
{
    private static readonly object flightAddLock = new();
    private readonly IFlightService _flightService;
    private readonly IAirportService _airportService;
    private readonly IMapper _mapper;
    private readonly IEnumerable<IValidateAddFlight> _validators;

    public AdminApiController(
        IFlightService flightService,
        IAirportService airportService,
        IMapper mapper,
        IEnumerable<IValidateAddFlight> validators)
    {
        _flightService = flightService;
        _airportService = airportService;
        _mapper = mapper;
        _validators = validators;
    }
    
    [HttpGet]
    [Route("flights/{id}")]
    public IActionResult GetFlights(int id)
    {
        var flight = _flightService.GetFullFlight(id);

        if (flight == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<AddFlightRequest>(flight));
    }

    [HttpPut]
    [Route("flights")]
    public IActionResult AddFlight(AddFlightRequest request)
    {
        lock (flightAddLock)
        {
            var flight = _mapper.Map<Flight>(request);

            if (!_validators.All(v => v.IsValid(flight)))
            {
                return BadRequest();
            }

            if (_flightService.FlightExists(flight))
            {
                return Conflict();
            }
            
            _flightService.Create(flight);

            return Created("", _mapper.Map<AddFlightRequest>(flight));
        }
    }

    [HttpDelete]
    [Route("flights/{id}")]
    public IActionResult DeleteFlight(int id)
    {
            var flight = _flightService.GetFullFlight(id);

            if (flight != null)
            {
                _flightService.Delete(flight);
                _airportService.Delete(flight.From);
                _airportService.Delete(flight.To);
            }

            return Ok();
    }
}