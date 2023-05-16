using FlightPlaner.Core.Models;

namespace FlightPlaner_ASPNET.Models;

public class PageResult
{
    public int Page { get; set; }
    public int TotalItems { get; set; }
    public List<Flight> Items { get; set; } = new List<Flight>();
}