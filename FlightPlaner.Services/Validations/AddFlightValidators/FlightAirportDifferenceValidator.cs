using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.AddFlightValidators
{
    public class FlightAirportDifferenceValidator : IValidateAddFlight
    {
        public bool IsValid(Flight flight)
        {
            return flight?.From?.AirportCode.ToLower().Trim() != flight?.To?.AirportCode.ToLower().Trim();
        }
    }
}
