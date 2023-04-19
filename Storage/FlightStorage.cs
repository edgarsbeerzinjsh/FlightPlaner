using FlightPlaner_ASPNET.Models;
using Microsoft.AspNetCore.Identity;

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

    public static bool IsAlreadyInFlights(Flight flight)
    {
        return _flights.Any(f => f.DepartureTime == flight.DepartureTime
                                 && f.ArrivalTime == flight.ArrivalTime
                                 && f.Carrier == flight.Carrier
                                 && f.From.City == flight.From.City
                                 && f.From.Country == flight.From.Country
                                 && f.From.AirportCode == flight.From.AirportCode
                                 && f.To.City == flight.To.City
                                 && f.To.Country == flight.To.Country
                                 && f.To.AirportCode == flight.To.AirportCode);
    }

    public static bool IsAllFieldsCorrect(Flight flight)
    {
        var hasDepartureTime = !string.IsNullOrEmpty(flight.DepartureTime);
        var hasArrivalTime = !string.IsNullOrEmpty(flight.ArrivalTime);
        var hasCarrier = !string.IsNullOrEmpty(flight.Carrier);
        var hasFromCity = !string.IsNullOrEmpty(flight.From.City);
        var hasFromCountry = !string.IsNullOrEmpty(flight.From.Country);
        var hasFromAirportCode = !string.IsNullOrEmpty(flight.From.AirportCode);
        var hasToCity = !string.IsNullOrEmpty(flight.To.City);
        var hasToCountry = !string.IsNullOrEmpty(flight.To.Country);
        var hasToAirportCode = !string.IsNullOrEmpty(flight.To.AirportCode);
        
        var hasAllPropertyValues = hasDepartureTime && hasArrivalTime && hasCarrier && hasFromCity && hasFromCountry &&
                                   hasFromAirportCode && hasToCity && hasToCountry && hasToAirportCode;
        
        var hasFromAndToDifferent = !(flight.From.City.ToLower().Trim() == flight.To.City.ToLower().Trim() &&
                                    flight.From.Country.ToLower().Trim() == flight.To.Country.ToLower().Trim() &&
                                    flight.From.AirportCode.ToLower().Trim() == flight.To.AirportCode.ToLower().Trim());

        var departureTime = Convert.ToDateTime(flight.DepartureTime);
        var arrivalTime = Convert.ToDateTime(flight.ArrivalTime);
        var hasPossibleFlightTime = arrivalTime > departureTime;
        
        return hasAllPropertyValues && hasFromAndToDifferent && hasPossibleFlightTime;
    }

    public static void Clear()
    {
        _flights.Clear();
        _id = 1;
    }
}