namespace EventPlanner.Dtos;

public class TicketDTO
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public required string AtendeeName { get; set; }
    public decimal PricePaid { get; set; }
    public bool IsEarlyBird { get; set; }
}