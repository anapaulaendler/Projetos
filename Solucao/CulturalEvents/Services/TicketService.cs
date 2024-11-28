using CulturalEvents.Interfaces;
using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IParticipantRepository _participantRepository;
    private readonly IEventRepository _eventRepository;

    public TicketService(ITicketRepository ticketRepository, IParticipantRepository participantRepository, IEventRepository eventRepository)
    {
        _ticketRepository = ticketRepository;
        _participantRepository = participantRepository;
        _eventRepository = eventRepository;
    }

    public async Task CreateTicketAsync(Ticket ticket)
    {
        ticket.Event = await _eventRepository.GetById(ticket.EventId);
        ticket.Participant = await _participantRepository.GetById(ticket.ParticipantId);

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