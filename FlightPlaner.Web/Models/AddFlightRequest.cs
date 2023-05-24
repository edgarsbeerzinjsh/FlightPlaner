using FlightPlaner.Core.Models;

namespace FlightPlaner_ASPNET.Models
{
    public class AddFlightRequest
    {
        public int Id { get; set; }
        public AddAirportRequest From { get; set; }
        public AddAirportRequest To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}
