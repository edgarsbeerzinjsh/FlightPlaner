using FlightPlaner_ASPNET.Models;

namespace FlightPlaner_ASPNET.Storage;

public static class FlightStorage
{
    private static List<Flight> _flights = new List<Flight>();
    private static int _id = 1;

    public static Flight GetFlight(int id)
    {
        return _flights.SingleOrDefault(flight => flight.Id == id);
    }

    public static Flight AddFlight(Flight flight)
    {
        flight.Id = _id++;
        _flights.Add(flight);
        return flight;
    }
    //SaveFlight
}