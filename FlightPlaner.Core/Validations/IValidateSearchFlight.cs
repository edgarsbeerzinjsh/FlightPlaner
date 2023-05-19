using FlightPlaner.Core.Models;

namespace FlightPlaner.Core.Validations
{
    public interface IValidateSearchFlight
    {
        bool IsValid(FlightSearchQuery search);
    }
}
