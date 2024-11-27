namespace CulturalEvents.Models;

public abstract class Event
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid ArtistId { get; set; }
    public required Artist Artist { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
    public int Capacity { get; set; }
    public decimal Fee { get; set; }

    public abstract void CalculateFee();
    public abstract void GenerateReport();
}