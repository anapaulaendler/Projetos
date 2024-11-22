namespace CulturalEvents.Models;

public class Artist : Person
{
    public required string Speciality { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Artist: {Name}, Id: {Id}, CPF: {Cpf}, E-mail: {Email}, Speciality: {Speciality}");
    }
}