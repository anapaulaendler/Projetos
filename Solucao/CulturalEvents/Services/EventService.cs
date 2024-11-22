using CulturalEvents.Interfaces;
using CulturalEvents.Models;
namespace CulturalEvents.Services;

public class EventService : IEventService
{
    public Event CreateConcert(Concert concert)
    {
        if (concert.Capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than zero.");
        }

        return concert;
    }

    public void DeleteEvent(int id)
    {
        throw new NotImplementedException();
    }

    public Event GetEventById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Event> GetEvents()
    {
        throw new NotImplementedException();
    }

    public List<Event> GetEventsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public Event UpdateEvent(string name, DateTime date, int capacity, int id)
    {
        throw new NotImplementedException();
    }
}
