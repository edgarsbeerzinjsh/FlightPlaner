using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using FlightPlaner.Data;

namespace FlightPlaner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlanerDbContext context) : base(context)
        {
        }

        public List<Airport> GetSearchAirports(string search)
        {
            var cleanedSearch = search.ToLower().Trim();

            return _context.Airports.Where(a => 
                   a.City.ToLower().Contains(cleanedSearch)
                || a.Country.ToLower().Contains(cleanedSearch)
                || a.AirportCode.ToLower().Contains(cleanedSearch))
                .ToList();
        }
    }
}
