using System.Text.Json.Serialization;

namespace FlightPlaner_ASPNET.Models;

public class Airport
{
    public string Country { get; set; }
    public string City { get; set; }
    [JsonPropertyName("airport")]
    public string AirportCode { get; set; }
}