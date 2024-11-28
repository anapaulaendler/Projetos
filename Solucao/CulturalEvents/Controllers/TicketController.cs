using CulturalEvents.Models;
using CulturalEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public async Task<Ticket> CreateTicket(Ticket ticket)
    {
        await _ticketService.CreateTicketAsync(ticket);
        return ticket;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketById(Guid id)
    {
        try
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return Ok(ticket);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Ticket>> GetTickets()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return tickets;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(Guid id)
    {
        try
        {
            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
