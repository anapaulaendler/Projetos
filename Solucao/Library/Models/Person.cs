namespace Library.Models;

public abstract class Person
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }

    public abstract void DisplayDetails();
}