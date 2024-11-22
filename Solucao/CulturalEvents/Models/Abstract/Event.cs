namespace CulturalEvents.Models;

public abstract class Event
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ArtistId { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
    public int Capacity { get; set; }

    public abstract void CalculateFee();
    public abstract void GenerateReport();
}

public enum TypeOfEvent
{
    Concert,
    Exhibition,
    TheatherPlay
}