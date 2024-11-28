using CulturalEvents.Interfaces;

namespace CulturalEvents.Models;

public class Payment : IPayment, IEntity
{
    public Guid Id { get; set; }

    public string IssueRecipt()
    {
        return $"Payment's ID: {Id}";
    }

    public string ProcessPayment(decimal amount)
    {
        return $"Confirmed payment: {amount} BRL";
    }
}
