using FlightPlaner_ASPNET.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner_ASPNET;

public class FlightPlanerDbContext : DbContext
{
    public FlightPlanerDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Flight> Flights { get; set; }
    
    public DbSet<Airport> Airports { get; set; }
}