namespace CulturalEvents.Models;

public class Exhibition : Event
{
    public int Duration { get; set; }
    public override void CalculateFee()
    {
        if (Artist is null)
        {
            throw new InvalidOperationException("Artist not found.");
        }

        if (string.IsNullOrEmpty(Artist.Name))
        {
            throw new InvalidOperationException("Artist name needed.");
        }

        var baseFee = 1000m;
        var durationMultiplier = (decimal)((Duration < 3) ? 2 : 4);

        Fee = baseFee * durationMultiplier;
    }


    public override void GenerateReport()
    {
        if (Artist is null)
        {
            throw new InvalidOperationException("Main artist not found.");
        }

        Console.WriteLine("Concert report: ");
        Console.WriteLine($"Main artist: {Artist.Name}");
        Console.WriteLine($"Duration: {Duration}");
        Console.WriteLine($"Fee: {Fee}");
    }
}