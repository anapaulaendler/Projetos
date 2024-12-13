using EventPlanner.Dtos;
using EventPlanner.Models;

namespace EventPlanner.Services;

public interface IEventService
{
    Task<List<Event>> GetAllEvents();
    Task<Event> GetEventById(Guid id);
    Task<Event> CreateEvent(EventDTO newEvent);
    Task<Event> UpdateEvent(Guid id, EventDTO updatedEvent);
    Task DeleteEvent(Guid id);
    List<Event> SearchEvents (string location, DateTime? startDate, DateTime? endDate);
}