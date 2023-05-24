using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.SearchFlightValidators
{
    public class SearchDepartureValidator : IValidateSearchFlight
    {
        public bool IsValid(FlightSearchQuery search)
        {
            return !string.IsNullOrEmpty(search?.DepartureDate);
        }
    }
}
