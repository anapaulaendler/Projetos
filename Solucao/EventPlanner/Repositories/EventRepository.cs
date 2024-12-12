using EventPlanner.Context;
using EventPlanner.Models;

namespace EventPlanner.Repositories;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(AppDbContext appContext) : base(appContext)
    {
    }
}