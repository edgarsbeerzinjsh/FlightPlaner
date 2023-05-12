using FlightPlaner_ASPNET.Models;

namespace FlightPlaner_ASPNET.PropertyValidation
{
    public static class InputValidation
    {
        public static string ToLowerAndTrim(string st)
        {
            return st.ToLower().Trim();
        }

        public static bool IsSearchFlightValid(CustomerSearchQuery searchQuery)
        {
            return IsNotNullOrEmptyEntry(searchQuery.From) &&
                   IsNotNullOrEmptyEntry(searchQuery.To) &&
                   IsNotNullOrEmptyEntry(searchQuery.DepartureDate) &&
                   searchQuery.From != searchQuery.To;
        }

        public static bool IsAllFlightFieldsCorrect(Flight flight)
        {
            return IsAllFlightPropertiesValid(flight) &&
                   HasTwoDifferentAirports(flight.From, flight.To) &&
                   HasPositiveTravelTime(flight);
        }


        private static bool IsAllFlightPropertiesValid(Flight flight)
        {
            return IsNotNullOrEmptyEntry(flight.DepartureTime) &&
                   IsNotNullOrEmptyEntry(flight.ArrivalTime) &&
                   IsNotNullOrEmptyEntry(flight.Carrier) &&
                   IsAllAirportPropertiesValid(flight.From) &&
                   IsAllAirportPropertiesValid(flight.To);
        }

        private static bool IsNotNullOrEmptyEntry(string entry)
        {
            return !string.IsNullOrEmpty(entry);
        }

        private static bool IsAllAirportPropertiesValid(Airport airport)
        {
            return IsNotNullOrEmptyEntry(airport.City) &&
                   IsNotNullOrEmptyEntry(airport.Country) &&
                   IsNotNullOrEmptyEntry(airport.AirportCode);
        }

        private static bool HasTwoDifferentAirports(Airport from, Airport to)
        {
            return !(ToLowerAndTrim(from.City) == ToLowerAndTrim(to.City) &&
                     ToLowerAndTrim(from.Country) == ToLowerAndTrim(to.Country) &&
                     ToLowerAndTrim(from.AirportCode) == ToLowerAndTrim(to.AirportCode));
        }

        private static bool HasPositiveTravelTime(Flight flight)
        {
            return Convert.ToDateTime(flight.ArrivalTime) > Convert.ToDateTime(flight.DepartureTime);
        }
    }
}