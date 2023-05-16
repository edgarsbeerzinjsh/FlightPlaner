using FlightPlaner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner.Data;

public class FlightPlanerDbContext : DbContext, IFlightPlanerDbContext
{
    public FlightPlanerDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Airport> Airports { get; set; }
}