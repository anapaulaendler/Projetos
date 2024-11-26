namespace CulturalEvents.Models;

public abstract class Person : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Cpf { get; set; }
    public required string Email { get; set; }

    public abstract string DisplayDetails();
}