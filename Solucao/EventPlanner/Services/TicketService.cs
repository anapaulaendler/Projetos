using EventPlanner.Context;
using EventPlanner.Dtos;
using EventPlanner.Models;
using EventPlanner.Repositories;

namespace EventPlanner.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _uow;

    public TicketService(ITicketRepository ticketRepository, IUnitOfWork uow, IEventRepository eventRepository)
    {
        _ticketRepository = ticketRepository;
        _uow = uow;
        _eventRepository = eventRepository;
    }

    public async Task CreateTicket(TicketDTO ticketDto)
    {
        await _uow.BeginTransactionAsync();
        var ticketEvent = await _eventRepository.GetById(ticketDto.EventId);

        var ticket = new Ticket
        {
            Id = ticketDto.Id,
            EventId = ticketDto.EventId,
            AtendeeName = ticketDto.AtendeeName,
            PricePaid = ticketDto.PricePaid,
            IsEarlyBird = ticketDto.IsEarlyBird,
            Event = ticketEvent
        };

        await _ticketRepository.AddAsync(ticket);
        await _uow.CommitTransactionAsync();
    }

    public async Task DeleteTicket(Guid id)
    {
        await _uow.BeginTransactionAsync();
        var ticket = await GetTicketById(id);

        await _ticketRepository.Delete(ticket);
        await _uow.CommitTransactionAsync();
    }

    // public Task<List<Ticket>> GetAllTickets()
    // {
    //     var tickets = _ticketRepository.Get();
    //     return tickets;
    // }
    // refazer, mas por evento

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
