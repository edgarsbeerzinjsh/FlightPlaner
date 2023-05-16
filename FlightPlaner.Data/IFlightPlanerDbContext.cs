using FlightPlaner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner.Data
{
    public interface IFlightPlanerDbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        public int SaveChanges();
    }
}
