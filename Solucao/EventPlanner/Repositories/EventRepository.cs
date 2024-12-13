using EventPlanner.Context;
using EventPlanner.Models;

namespace EventPlanner.Repositories;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public List<Event> FilterByLocation(string location)
    {
        List<Event> events = _dbSet.Where(x => x.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();

        return events;
    }

    public List<Event> FilterByLocationAndDate(string location, DateTime startDate, DateTime? endDate)
    {
        List<Event> events = _dbSet.Where(x => x.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
        
        if (endDate is not null)
        {
            events = events.Where(x => x.Date >= startDate && x.Date <= endDate).ToList();
        } else 
        {
            events = events.Where(x => x.Date >= startDate).ToList();
        }

        return events;
    }
}