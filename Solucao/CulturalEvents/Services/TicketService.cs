using CulturalEvents.Interfaces;
using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task CreateTicketAsync(Ticket ticket)
    {
        await _ticketRepository.AddAsync(ticket);
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return await _ticketRepository.Get();
    }

    public async Task<Ticket> GetTicketByIdAsync(Guid id)
    {
        return await _ticketRepository.GetById(id);
    }

    public async Task DeleteTicketAsync(Guid id)
    {
        var ticket = await _ticketRepository.GetById(id);
        await _ticketRepository.Delete(ticket);
    }

}