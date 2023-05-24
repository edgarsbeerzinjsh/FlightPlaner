using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.AddFlightValidators
{
    public class FlightValidator : IValidateAddFlight
    {
        public bool IsValid(Flight flight)
        {
            return flight != null;
        }
    }
}
