using EventPlanner.Context;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Repositories;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(AppDbContext appContext) : base(appContext)
    {
    }
    
    public List<Event> FilterByLocationAndDate(string location, DateTime startDate, DateTime? endDate)
    {
        var events = _dbSet.Where(x => x.Location == location);
        
        if (endDate is not null)
        {
            events = events.Where(x => x.Date >= startDate && x.Date <= endDate);
        } else 
        {
            events = events.Where(x => x.Date >= startDate);
        }

        return events.ToList();
    }

    public List<Event> FilterByLocation(string location)
    {
        var events = _dbSet.Where(x => x.Location == location);

        return events.ToList();
    }
}