namespace CulturalEvents.Models;

public class Exhibition : Event
{
    public required string MainArtist { get; set; }
    public required string Duration { get; set; }
    public override void CalculateFee()
    {
        throw new NotImplementedException();
    }

    public override void GenerateReport()
    {
        throw new NotImplementedException();
    }
}