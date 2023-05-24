using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.AddFlightValidators
{
    public class AirportValidator : IValidateAddFlight
    {
        public bool IsValid(Flight flight)
        {
            return flight?.From != null && flight?.To != null;
        }
    }
}
