using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using FlightPlaner.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlanerDbContext context) : base(context)
        {
        }

        public Flight GetFullFlight(int id)
        {
            return _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .SingleOrDefault(f => f.Id == id);
        }
    }
}
