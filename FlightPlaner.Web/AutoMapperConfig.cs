using AutoMapper;
using FlightPlaner.Core.Models;
using FlightPlaner_ASPNET.Models;

namespace FlightPlaner_ASPNET
{
    public static class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AddAirportRequest, Airport>()
                        .ForMember(d => d.AirportCode, opt => opt.MapFrom(s => s.Airport))
                        .ForMember(d => d.Id, opt => opt.Ignore());
                    cfg.CreateMap<Airport, AddAirportRequest>()
                        .ForMember(d => d.Airport, opt => opt.MapFrom(s => s.AirportCode));
                    cfg.CreateMap<AddFlightRequest, Flight>();
                    cfg.CreateMap<Flight, AddFlightRequest>();
                }
            );

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
