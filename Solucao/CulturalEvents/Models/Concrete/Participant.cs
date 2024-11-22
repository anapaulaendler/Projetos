namespace CulturalEvents.Models;

public class Participant : Person
{
    public override void DisplayDetails()
    {
        Console.WriteLine($"Artist: {Name}, Id: {Id}, CPF: {Cpf}, E-mail: {Email}");
    }
}