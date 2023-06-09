﻿using FlightPlaner.Core.Models;

namespace FlightPlaner.Core.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        List<Airport> SearchAirports(string search);
    }
}
