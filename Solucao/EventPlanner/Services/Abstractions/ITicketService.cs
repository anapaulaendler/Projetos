using EventPlanner.Dtos;
using EventPlanner.Models;

namespace EventPlanner.Services;

public interface ITicketService
{
    Task<Ticket> CreateTicket(TicketDTO ticket);
    Task<List<Ticket>> GetTicketsByEventIdAsync(Guid eventId);
    Task<Ticket> GetTicketById(Guid id);
    Task<Ticket> UpdateTicket(Guid id, TicketDTO updatedTicket);
    Task DeleteTicket(Guid id);
}