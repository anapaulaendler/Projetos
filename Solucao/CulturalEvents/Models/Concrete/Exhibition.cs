namespace CulturalEvents.Models;

public class Exhibition : Event
{
    public Artist? MainArtist { get; set; }
    public int Duration { get; set; }
    public override void CalculateFee()
    {
        if (MainArtist is null)
        {
            throw new InvalidOperationException("Artist not found.");
        }

        if (string.IsNullOrEmpty(MainArtist.Name))
        {
            throw new InvalidOperationException("Artist name needed.");
        }

        var baseFee = 1000m;
        var durationMultiplier = (decimal)((Duration < 3) ? 2 : 4);

        Fee = baseFee * durationMultiplier;
    }


    public override void GenerateReport()
    {
        if (MainArtist is null)
        {
            throw new InvalidOperationException("Artist not found.");
        }

        Console.WriteLine("Concert report: ");
        Console.WriteLine($"Artist: {MainArtist.Name}");
        Console.WriteLine($"Duration: {Duration}");
        Console.WriteLine($"Fee: {Fee}");
    }
}