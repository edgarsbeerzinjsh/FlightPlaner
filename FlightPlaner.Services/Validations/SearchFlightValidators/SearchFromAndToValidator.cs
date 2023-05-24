using FlightPlaner.Core.Models;
using FlightPlaner.Core.Validations;

namespace FlightPlaner.Services.Validations.SearchFlightValidators
{
    public class SearchFromAndToValidator : IValidateSearchFlight
    {
        public bool IsValid(FlightSearchQuery search)
        {
            return !string.IsNullOrEmpty(search?.From) 
                && !string.IsNullOrEmpty(search?.To)
                && search?.From != search?.To;
        }
    }
}
