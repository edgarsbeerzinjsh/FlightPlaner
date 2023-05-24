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

        public bool FlightExists(Flight flight)
        {
            return _context.Flights
                .Any(f => f.DepartureTime == flight.DepartureTime
                            && f.ArrivalTime == flight.ArrivalTime
                            && f.Carrier == flight.Carrier
                            && f.From.City == flight.From.City
                            && f.From.Country == flight.From.Country
                            && f.From.AirportCode == flight.From.AirportCode
                            && f.To.City == flight.To.City
                            && f.To.Country == flight.To.Country
                            && f.To.AirportCode == flight.To.AirportCode);
        }

        public PageResult SearchFlights(FlightSearchQuery search)
        {
            var items = _context.Flights
                    .Include(f => f.From)
                    .Include(f => f.To)
                    .AsEnumerable()
                    .Where(f => f.From.AirportCode == search.From &&
                                f.To.AirportCode == search.To &&
                                Convert.ToDateTime(f.DepartureTime) >= Convert.ToDateTime(search.DepartureDate)).ToList();

            return new PageResult() { Page = 0, TotalItems = items.Count, Items = items};
        }
    }
}
