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

    // [HttpPost]
    // public async Task<Event> CreateEvent(EventDTO eventDTO)
    // {
    //     await _eventService.CreateEvent(eventDTO);


    // }
}