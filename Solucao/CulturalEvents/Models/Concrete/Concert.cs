namespace CulturalEvents.Models;

public class Concert : Event
{
    public required string MusicGenre { get; set; }
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
        var genreMultiplier = MusicGenre?.ToLower() switch
        {
            "pop" => 1.5m,
            "rock" => 1.3m,
            "classical" => 1.2m,
            _ => 1.0m
        };

        Fee = baseFee * genreMultiplier;
    }

    public override void GenerateReport()
    {
        if (Artist is null)
        {
            throw new InvalidOperationException("Artist not found.");
        }

        Console.WriteLine("Concert report: ");
        Console.WriteLine($"Artist: {Artist.Name}");
        Console.WriteLine($"Genre: {MusicGenre}");
        Console.WriteLine($"Fee: {Fee}");
    }
}