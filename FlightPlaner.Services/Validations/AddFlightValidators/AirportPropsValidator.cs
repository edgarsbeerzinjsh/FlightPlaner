using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.AddFlightValidators
{
    public class AirportPropsValidator : IValidateAddFlight
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.From?.AirportCode)
                && !string.IsNullOrEmpty(flight?.From?.Country)
                && !string.IsNullOrEmpty(flight?.From?.City)
                && !string.IsNullOrEmpty(flight?.To?.AirportCode)
                && !string.IsNullOrEmpty(flight?.To?.Country)
                && !string.IsNullOrEmpty(flight?.To?.City);
        }
    }
}
