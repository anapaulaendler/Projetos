namespace CulturalEvents.Models;

public class TheaterPlay : Event
{
    public Artist? Director { get; set; }
    public required ICollection<string> Cast { get; set; }
    public override void CalculateFee()
    {
        if (Director is null)
        {
            throw new InvalidOperationException("Artist not found.");
        }

        if (string.IsNullOrEmpty(Director.Name))
        {
            throw new InvalidOperationException("Artist name needed.");
        }

        var baseFee = 1000m;
        var castMultiplier = (decimal)((Cast.Count() < 5) ? 2 : 4);

        Fee = baseFee * castMultiplier;
    }


    public override void GenerateReport()
    {
        if (Director is null)
        {
            throw new InvalidOperationException("Artist not found.");
        }

        Console.WriteLine("Concert report: ");
        Console.WriteLine($"Artist: {Director.Name}");
        Console.WriteLine($"Cast: {Cast}");
        Console.WriteLine($"Fee: {Fee}");
    }
}