using EventPlanner.Interfaces;

namespace EventPlanner.Models;

public class Ticket : IEntity
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public required string AtendeeName { get; set; }
    public decimal PricePaid { get; set; }
    public bool IsEarlyBird { get; set; }

    public required Event Event { get; set; }

    public void ApplyEarlyBirdDiscount()
    {
        if (IsEarlyBird)
        {
            PricePaid = PricePaid * 0.8m;
        } 
    }
}
