namespace CulturalEvents.Models;

public class Participant : Person
{
        public override string DisplayDetails()
    {
        return $"Participant: {Name}, Id: {Id}, CPF: {Cpf}, E-mail: {Email}";
    }
}