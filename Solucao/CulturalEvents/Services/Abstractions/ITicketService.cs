using CulturalEvents.Models;

namespace CulturalEvents.Services
{
    public interface ITicketService
    {
        Task CreateTicketAsync(Ticket ticket);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(Guid id);
        Task DeleteTicketAsync(Guid id);
    }
}