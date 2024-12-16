using EventPlanner.Context;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Repositories;

public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
{
    public TicketRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<List<Ticket>> GetTicketsByEventId(Guid eventId)
    {
        List<Ticket> query = await _dbSet.Where(x => x.EventId == eventId).ToListAsync();

        if (query is null || query.Count() < 1)
        {
            throw new Exception();
        }

        return query;
    }
}
