using CulturalEvents.Models;

namespace CulturalEvents.Interfaces;

public interface ITicketService
{
    Ticket CreateTicket(int idE, int idP, decimal price);
    List<Ticket> GetTicketsByDate(DateTime date);
    Ticket GetTicketById(int id);
    List<Ticket> GetTickets();
    Ticket UpdateTicket(bool status, int id);
    void DeleteTicket(int id);
}