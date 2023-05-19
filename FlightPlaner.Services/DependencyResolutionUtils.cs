using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using FlightPlaner.Core.Validations;
using FlightPlaner.Services.Validations.AddFlightValidators;
using FlightPlaner.Services.Validations.SearchFlightValidators;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlaner.Services
{
    public static class DependencyResolutionUtils
    {
        public static void RegisterValidations(this IServiceCollection services)
        {
            services.AddScoped<IValidateAddFlight, FlightValidator>();
            services.AddScoped<IValidateAddFlight, FlightCarrierValidator>();
            services.AddScoped<IValidateAddFlight, FlightTimeValidator>();
            services.AddScoped<IValidateAddFlight, FlightTimeDifferenceValidator>();
            services.AddScoped<IValidateAddFlight, FlightAirportDifferenceValidator>();
            services.AddScoped<IValidateAddFlight, AirportValidator>();
            services.AddScoped<IValidateAddFlight, AirportPropsValidator>();
            services.AddScoped<IValidateSearchFlight, SearchFromAndToValidator>();
            services.AddScoped<IValidateSearchFlight, SearchDepartureValidator>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Flight>, EntityService<Flight>>();
            services.AddScoped<IEntityService<Airport>, EntityService<Airport>>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IAirportService, AirportService>();
        }
    }
}
