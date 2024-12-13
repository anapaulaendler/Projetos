using EventPlanner.Dtos;
using EventPlanner.Models;
using EventPlanner.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers;

[ApiController]
[Route("ticket")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;
    private readonly ILogger<TicketController> _logger;

    public TicketController(ITicketService ticketService, ILogger<TicketController> logger)
    {
        _ticketService = ticketService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<Ticket> CreateTicket(TicketDTO ticketDTO)
    {
        return await _ticketService.CreateTicket(ticketDTO);
    }

    [HttpGet("event/{id}")]
    public async Task<IActionResult> GetTicketsByEventId(Guid eventId)
    {
        try
        {
            List<Ticket> tickets = await _ticketService.GetTicketsByEventIdAsync(eventId);

            // if (tickets is null || tickets.Count() < 1)
            // {
            //     _logger.LogInformation("Erro!");
            // }

            return Ok(tickets);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketById(Guid id)
    {
        try
        {
            var ticket = await _ticketService.GetTicketById(id);
            return Ok(ticket);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(Guid id, TicketDTO updatedTicket)
    {
        try
        {
            var ticket = await _ticketService.UpdateTicket(id, updatedTicket);
            return Ok(ticket);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(Guid id)
    {
        try
        {
            await _ticketService.DeleteTicket(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}