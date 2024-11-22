namespace CulturalEvents.Models;

public abstract class Person
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Cpf { get; set; }
    public required string Email { get; set; }

    public abstract void DisplayDetails();
}