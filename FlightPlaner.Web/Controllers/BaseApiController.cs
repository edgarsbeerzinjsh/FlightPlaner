using FlightPlaner.Core.Models;
using FlightPlaner.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner_ASPNET.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected IFlightPlanerDbContext _context;

        protected BaseApiController(IFlightPlanerDbContext context)
        {
            _context = context;
        }

        protected Flight? FlightInContext(int id)
        {
            return _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .SingleOrDefault(flight => flight.Id == id);
        }
    }
}
