namespace CulturalEvents.Models;

public class Ticket : IEntity
{
    public Guid Id { get; set; }
    public Event? Event { get; set; }
    public Guid EventId { get; set; }
    // no tpc, tirar evento e substituir pelo ? das filhas
    public Participant? Participant { get; set; }
    public Guid ParticipantId { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; } = false;

    public void Reserve()
    {
        throw new NotImplementedException();
    }

    public void ConfirmPayment()
    {
        throw new NotImplementedException();
    }
}