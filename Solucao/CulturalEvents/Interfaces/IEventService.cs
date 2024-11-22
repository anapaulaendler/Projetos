using CulturalEvents.Models;
using Microsoft.AspNetCore.Components.Routing;

namespace CulturalEvents.Interfaces;

public interface IEventService
{
    Event CreateConcert(Concert concert);
    List<Event> GetEventsByDate(DateTime date);
    Event GetEventById(int id);
    List<Event> GetEvents();
    Event UpdateEvent(string name, DateTime date, int capacity, int id);
    void DeleteEvent(int id);

}