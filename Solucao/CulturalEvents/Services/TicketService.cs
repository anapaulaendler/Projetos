using CulturalEvents.Interfaces;
using CulturalEvents.Models;
namespace CulturalEvents.Services;

public class TicketService : ITicketService
{
    public Ticket CreateTicket(int idE, int idP, decimal price)
    {
        throw new NotImplementedException();
    }

    public void DeleteTicket(int id)
    {
        throw new NotImplementedException();
    }

    public Ticket GetTicketById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Ticket> GetTickets()
    {
        throw new NotImplementedException();
    }

    public List<Ticket> GetTicketsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public Ticket UpdateTicket(bool status, int id)
    {
        throw new NotImplementedException();
    }
}