using FlightPlaner.Core.Models;

namespace FlightPlaner.Core.Validations
{
    public interface IValidateAddFlight
    {
        bool IsValid(Flight flight);
    }
}
