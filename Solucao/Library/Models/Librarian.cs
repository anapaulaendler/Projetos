namespace Library.Models;

public class Librarian : Person
{
    public override void DisplayDetails()
    {
        Console.WriteLine($"Employee ID: {Id}, Name: {Name}, E-mail: {Email}, Phone Number: {PhoneNumber}");
    }
}