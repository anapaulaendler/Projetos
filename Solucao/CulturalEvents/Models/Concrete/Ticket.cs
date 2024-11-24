namespace CulturalEvents.Models;

public class Ticket : IEntity
{
    public Guid Id { get; set; }
    // public Event? Event { get; set; }
    // public int ParticipantId { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }

    public void Reserve()
    {
        throw new NotImplementedException();
    }

    public void ConfirmPayment()
    {
        throw new NotImplementedException();
    }
}