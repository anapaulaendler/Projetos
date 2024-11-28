using CulturalEvents.Models;

namespace CulturalEvents.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}