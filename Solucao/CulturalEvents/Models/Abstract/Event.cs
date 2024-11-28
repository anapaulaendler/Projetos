namespace CulturalEvents.Models;

public class Event : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid ArtistId { get; set; }
    public Artist? Artist { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
    public int Capacity { get; set; }
    public decimal Fee { get; set; }
    // public void CalculateFee();
    // public void GenerateReport();
}