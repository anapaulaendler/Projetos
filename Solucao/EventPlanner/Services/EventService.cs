using System.Linq.Expressions;
using EventPlanner.Context;
using EventPlanner.Dtos;
using EventPlanner.Extensions;
using EventPlanner.Models;
using EventPlanner.Repositories;

namespace EventPlanner.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _uow;
    private readonly IOrganizerRepository _organizerRepository;

    public EventService(IEventRepository eventRepository, IUnitOfWork uow, IOrganizerRepository organizerRepository)
    {
        _eventRepository = eventRepository;
        _uow = uow;
        _organizerRepository = organizerRepository;
    }

    public async Task<Event> CreateEvent(EventDTO newEvent)
    {
        await _uow.BeginTransactionAsync();
        var organizer = await _organizerRepository.GetById(newEvent.OrganizerId);

        var createEvent = new Event
        {
            Id = newEvent.Id,
            OrganizerId = newEvent.OrganizerId,
            Name = newEvent.Name,
            Description = newEvent.Description,
            Date = newEvent.Date,
            Location = newEvent.Location,
            Price = newEvent.Price,
            MaxAttendees = newEvent.MaxAttendees,
            CurrentAttendees = newEvent.CurrentAttendees,
            Organizer = organizer
        };

        await _eventRepository.AddAsync(createEvent);
        await _uow.CommitTransactionAsync();

        return createEvent;
    }

    public async Task DeleteEvent(Guid id)
    {
        await _uow.BeginTransactionAsync();
        var deleteEvent = await GetEventById(id);

        await _eventRepository.Delete(deleteEvent);
        await _uow.CommitTransactionAsync();
    }

    public async Task<List<Event>> GetAllEvents()
    {
        var getEvents = await _eventRepository.Get();
        return getEvents;
    }

    public async Task<Event> GetEventById(Guid id)
    {
        var getEvent = await _eventRepository.GetById(id);
        return getEvent;
    }

    public List<Event> SearchEvents(string location, DateTime? startDate, DateTime? endDate)
    {
        List<Event> eventLocations = _eventRepository.FilterByLocation(location);
        List<Event> events = eventLocations;

        if (startDate is not null)
        {
            events = _eventRepository.FilterByLocationAndDate(location, (DateTime)startDate, endDate);
        } 

        return events;
    }

    public async Task<Event> UpdateEvent(Guid id, EventDTO updatedEvent)
    {
        await _uow.BeginTransactionAsync();
        
        var currentEvent = await GetEventById(id);

        if (currentEvent is null)
        {
            throw new KeyNotFoundException();
        }

        var organizer = await _organizerRepository.GetById(updatedEvent.OrganizerId);
        
        currentEvent.OrganizerId = updatedEvent.OrganizerId;
        currentEvent.Name = updatedEvent.Name;
        currentEvent.Description = updatedEvent.Description;
        currentEvent.Date = updatedEvent.Date;
        currentEvent.Location = updatedEvent.Location;
        currentEvent.Price = updatedEvent.Price;
        currentEvent.MaxAttendees = updatedEvent.MaxAttendees;
        currentEvent.CurrentAttendees = updatedEvent.CurrentAttendees;
        currentEvent.Organizer = organizer;

        await _eventRepository.Update(currentEvent);
        await _uow.CommitTransactionAsync();

        return currentEvent;
    }
}
