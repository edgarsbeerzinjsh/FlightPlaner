using FlightPlaner.Core.Models;

namespace FlightPlaner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight GetFullFlight(int id);

        bool FlightExists(Flight flight);

        PageResult SearchFlights(FlightSearchQuery search);
    }
}
