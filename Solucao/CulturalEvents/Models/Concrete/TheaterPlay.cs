namespace CulturalEvents.Models;

public class TheaterPlay : Event
{
    public required string Director { get; set; }
    public required string Cast { get; set; }
    public override void CalculateFee()
    {
        throw new NotImplementedException();
    }

    public override void GenerateReport()
    {
        throw new NotImplementedException();
    }
}