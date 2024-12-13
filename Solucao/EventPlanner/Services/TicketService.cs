using EventPlanner.Context;
using EventPlanner.Dtos;
using EventPlanner.Extensions;
using EventPlanner.Models;
using EventPlanner.Repositories;

namespace EventPlanner.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _uow;
    private readonly ILogger<TicketService> _logger;

    public TicketService(ITicketRepository ticketRepository, IUnitOfWork uow, IEventRepository eventRepository, ILogger<TicketService> logger)
    {
        _ticketRepository = ticketRepository;
        _uow = uow;
        _eventRepository = eventRepository;
        _logger = logger;
    }

    public async Task<Ticket> CreateTicket(TicketDTO ticketDto)
    {
        await _uow.BeginTransactionAsync();
        var ticketEvent = await _eventRepository.GetById(ticketDto.EventId);

        var ticket = new Ticket
        {
            Id = ticketDto.Id,
            EventId = ticketDto.EventId,
            AtendeeName = ticketDto.AtendeeName,
            PricePaid = ticketEvent.Price,
            IsEarlyBird = ticketDto.IsEarlyBird,
            Event = ticketEvent
        };

        ticket.ApplyEarlyBirdDiscount();

        await _ticketRepository.AddAsync(ticket);
        await _uow.CommitTransactionAsync();

        return ticket;
    }

    public async Task DeleteTicket(Guid id)
    {
        await _uow.BeginTransactionAsync();
        var ticket = await GetTicketById(id);

        await _ticketRepository.Delete(ticket);
        await _uow.CommitTransactionAsync();
    }

    public async Task<List<Ticket>> GetTicketsByEventIdAsync(Guid id)
    {
        List<Ticket> tickets = await _ticketRepository.Get();
        List<Ticket> eventTickets = tickets.Where(x => x.EventId == id).ToList();
        return eventTickets;
    }

    public async Task<Ticket> GetTicketById(Guid id)
    {
        var ticket = await _ticketRepository.GetById(id);

        return ticket;
    }

    public async Task<Ticket> UpdateTicket(Guid id, TicketDTO updatedTicket)
    {
        await _uow.BeginTransactionAsync();
        
        var ticket = await GetTicketById(id);

        ticket.AtendeeName = updatedTicket.AtendeeName;
        
        await _ticketRepository.Update(ticket);
        await _uow.CommitTransactionAsync();

        return ticket;
    }
}
