using EventPlanner.Dtos;
using EventPlanner.Models;

namespace EventPlanner.Services;

public interface ITicketService
{
    Task CreateTicket(TicketDTO ticket);
    // Task<List<Ticket>> GetAllTickets();
    Task<Ticket> GetTicketById(Guid id);
    Task<Ticket> UpdateTicket(Guid id, TicketDTO updatedTicket);
    Task DeleteTicket(Guid id);
}