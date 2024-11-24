namespace CulturalEvents.Models;

public class Concert : Event
{
    public string? MusicGenre { get; set; }
    public string? Artist { get; set; }
    public override void CalculateFee()
    {
        if (string.IsNullOrEmpty(Artist))
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
        Console.WriteLine("Concert report: ");
        Console.WriteLine($"Artist: {Artist}");
        Console.WriteLine($"Genre: {MusicGenre}");
        Console.WriteLine($"Fee: {Fee}");
    }
}