namespace Library.Models;

public class Member : Person
{
    public required string Adress { get; set; }
    public double Fine { get; set; } = 0;
    public override void DisplayDetails()
    {
        Console.WriteLine($"Membership ID: {Id}, Name: {Name}, E-mail: {Email}, Phone Number: {PhoneNumber}, Adress: {Adress}, Fines (Total): R$ {Fine}");
    }
}