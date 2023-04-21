using FlightPlaner_ASPNET.Models;
using Microsoft.AspNetCore.Identity;

namespace FlightPlaner_ASPNET.Storage;

public static class FlightStorage
{
    private static List<Flight> _flights = new List<Flight>();
    private static int _id = 1;

    public static PageResult SearchFlights(CustomerSearchQuery searchQuery)
    {
        var answer = new PageResult() {Page=0, TotalItems = 0};
        foreach (var flight in _flights)
        {
            if (searchQuery.From == flight.From.AirportCode && 
                searchQuery.To == flight.To.AirportCode &&
                Convert.ToDateTime(searchQuery.DepartureDate) < Convert.ToDateTime(flight.DepartureTime))
            {
                answer.TotalItems++;
                answer.Items.Add(flight);
            }
        }
        
        return answer;
    }

    public static bool IsSearchFlightValid(CustomerSearchQuery searchQuery)
    {
        return IsNotNullOrEmptyEntry(searchQuery.From) && 
               IsNotNullOrEmptyEntry(searchQuery.To) &&
               IsNotNullOrEmptyEntry(searchQuery.DepartureDate) &&
               searchQuery.From != searchQuery.To;
    }
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

    public static void DeleteFlight(int id)
    {
        var flight = GetFlight(id);
        _flights.Remove(flight);
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

    public static bool IsAllFlightFieldsCorrect(Flight flight)
    {
        return IsAllFlightPropertiesValid(flight) && 
               HasTwoDifferentAirports(flight.From, flight.To) &&
               HasPositiveTravelTime(flight);
    }

    public static void Clear()
    {
        _flights.Clear();
        _id = 1;
    }
    
    private static bool IsAllFlightPropertiesValid(Flight flight)
    {
        return IsNotNullOrEmptyEntry(flight.DepartureTime) && 
               IsNotNullOrEmptyEntry(flight.ArrivalTime) &&
               IsNotNullOrEmptyEntry(flight.Carrier) && 
               IsAllAirportPropertiesValid(flight.From) &&
               IsAllAirportPropertiesValid(flight.To);
    }

    private static bool IsNotNullOrEmptyEntry(string entry)
    {
        return !string.IsNullOrEmpty(entry);
    }

    private static bool IsAllAirportPropertiesValid(Airport airport)
    {
        return IsNotNullOrEmptyEntry(airport.City) && 
               IsNotNullOrEmptyEntry(airport.Country) &&
               IsNotNullOrEmptyEntry(airport.AirportCode);
    }

    private static bool HasTwoDifferentAirports(Airport from, Airport to)
    {
        return !(ToLowerAndTrim(from.City) == ToLowerAndTrim(to.City) &&
                 ToLowerAndTrim(from.Country) == ToLowerAndTrim(to.Country) &&
                 ToLowerAndTrim(from.AirportCode) == ToLowerAndTrim(to.AirportCode));
    }

    private static string ToLowerAndTrim(string st)
    {
        return st.ToLower().Trim();
    }

    private static bool HasPositiveTravelTime(Flight flight)
    {
        return Convert.ToDateTime(flight.ArrivalTime) > Convert.ToDateTime(flight.DepartureTime);
    }
}