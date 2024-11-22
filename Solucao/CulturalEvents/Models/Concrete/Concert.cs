namespace CulturalEvents.Models;

public class Concert : Event
{
    public string? MusicGenre { get; set; }
    public string? Artist { get; set; }
    public override void CalculateFee()
    {
        throw new NotImplementedException();
    }

    public override void GenerateReport()
    {
        throw new NotImplementedException();
    }
}