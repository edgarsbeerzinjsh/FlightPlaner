namespace FlightPlaner.Core.Models;

public class Airport : Entity
{
    public string Country { get; set; }
    public string City { get; set; }
    public string AirportCode { get; set; }
}