using EventPlanner.Models;

namespace EventPlanner.Extensions;

public static class TicketExtensions
{
    public static void ApplyEarlyBirdDiscount(this Ticket ticket)
    {
        if (ticket.IsEarlyBird)
        {
            ticket.PricePaid = ticket.PricePaid * 0.8m;
        } 
    }
}