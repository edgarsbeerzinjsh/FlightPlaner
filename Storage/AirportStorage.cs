using FlightPlaner_ASPNET.Models;

namespace FlightPlaner_ASPNET.Storage;

public static class AirportStorage
{
    private static List<Airport> _airports = new List<Airport>();

    public static void AddAirport(Airport airport)
    {
        if (!IsAlreadyInAirports(airport))
        {
            _airports.Add(airport);
        }
    }

    public static List<Airport> SearchAirport(string searchString)
    {
        var searchForAirport = _airports.FindAll(a =>
            a.City.ToLower().Contains(searchString.ToLower().Trim()) ||
            a.Country.ToLower().Contains(searchString.ToLower().Trim()) ||
            a.AirportCode.ToLower().Contains(searchString.ToLower().Trim()));
        return searchForAirport;
    }
    
    private static bool IsAlreadyInAirports(Airport airport)
    {
        return _airports.Any(a => a.City == airport.City
                                   && a.Country == airport.Country
                                   && a.AirportCode == airport.AirportCode);
    }
    
    
}