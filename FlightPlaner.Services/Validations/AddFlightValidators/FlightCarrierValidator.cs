using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.AddFlightValidators
{
    public class FlightCarrierValidator : IValidateAddFlight
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.Carrier);
        }
    }
}
