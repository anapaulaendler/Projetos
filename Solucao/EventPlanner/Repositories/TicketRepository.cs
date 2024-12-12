using EventPlanner.Context;
using EventPlanner.Models;

namespace EventPlanner.Repositories;

public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
{
    public TicketRepository(AppDbContext appContext) : base(appContext)
    {
    }
}
