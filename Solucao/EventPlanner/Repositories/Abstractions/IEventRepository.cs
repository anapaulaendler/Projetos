using EventPlanner.Models;

namespace EventPlanner.Repositories;

public interface IEventRepository : IRepositoryBase<Event>
{
    List<Event> FilterByLocation(string location);
    List<Event> FilterByLocationAndDate(string location, DateTime startDate, DateTime? endDate);
}