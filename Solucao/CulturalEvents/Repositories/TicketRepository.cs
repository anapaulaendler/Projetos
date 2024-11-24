using CulturalEvents.Models;

namespace CulturalEvents.Repositories
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}