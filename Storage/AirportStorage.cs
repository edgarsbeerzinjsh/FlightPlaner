using FlightPlaner_ASPNET.Models;

namespace FlightPlaner_ASPNET.Storage;

public static class AirportStorage
{
    private static List<Airport> _airports = new List<Airport>();

    public static void Clear()
    {
        _airports.Clear();
    }
    
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
            a.City.ToLower().Contains(ToLowerAndTrim(searchString)) ||
            a.Country.ToLower().Contains(ToLowerAndTrim(searchString)) ||
            a.AirportCode.ToLower().Contains(ToLowerAndTrim(searchString)));
        return searchForAirport;
    }
    
    private static string ToLowerAndTrim(string st)
    {
        return st.ToLower().Trim();
    }
    
    private static bool IsAlreadyInAirports(Airport airport)
    {
        return _airports.Count > 0 && 
               _airports.Any(a => a.City == airport.City
                                  && a.Country == airport.Country
                                  && a.AirportCode == airport.AirportCode);
        }
}