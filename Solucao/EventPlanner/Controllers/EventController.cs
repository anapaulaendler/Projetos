using EventPlanner.Dtos;
using EventPlanner.Models;
using EventPlanner.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers;

[ApiController]
[Route("event")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    public async Task<Event> CreateEvent(EventDTO eventDTO)
    {
        return await _eventService.CreateEvent(eventDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(Guid id)
    {
        try
        {
            var eventFound = await _eventService.GetEventById(id);
            return Ok(eventFound);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{location}/{startDate}/{endDate}")]
    public async Task<IActionResult> SearchEvent(string location, DateTime? startDate, DateTime? endDate)
    {
        try
        {
            var eventFound = _eventService.SearchEvents(location, startDate, endDate);
            return Ok(eventFound);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<List<Event>> GetEvents()
    {
        return await _eventService.GetAllEvents();
    }

    [HttpPut("{id}")]
    public async Task<Event> EditEvent(Guid id, EventDTO eventDTO)
    {
        return await _eventService.UpdateEvent(id, eventDTO);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        try
        {
            await _eventService.DeleteEvent(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}