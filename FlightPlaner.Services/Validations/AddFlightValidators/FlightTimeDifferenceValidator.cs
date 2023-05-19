using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.AddFlightValidators
{
    public class FlightTimeDifferenceValidator : IValidateAddFlight
    {
        public bool IsValid(Flight flight)
        {
            return DateTime.TryParse(flight?.DepartureTime, out var departure)
                && DateTime.TryParse(flight?.ArrivalTime, out var arrival)
                && departure < arrival;
        }
    }
}
