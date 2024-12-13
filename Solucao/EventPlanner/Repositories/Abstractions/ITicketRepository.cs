using EventPlanner.Models;

namespace EventPlanner.Repositories;

public interface ITicketRepository : IRepositoryBase<Ticket>
{
    // Task<List<Ticket>> GetTicketsByEventId(Guid eventId);
}