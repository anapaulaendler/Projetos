using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class ConcertService
{
    private readonly IConcertRepository _concertRepository;
    private readonly ITicketRepository _ticketRepository;

    private ConcertService(IConcertRepository concertRepository, ITicketRepository ticketRepository)
    {
        _concertRepository = concertRepository;
        _ticketRepository = ticketRepository;
    }

    public async Task CreateConcertAsync(Concert concert)
    {
        await _concertRepository.AddAsync(concert);
    }

    public async Task<IEnumerable<Concert>> GetAllConcertsAsync()
    {
        return await _concertRepository.Get();
    }

    public async Task<Concert> GetConcertByIdAsync(Guid id)
    {
        return await _concertRepository.GetById(id);
    }

    public async Task UpdateConcertAsync(Concert concert)
    {
        await _concertRepository.Update(concert);
    }

    public async Task DeleteConcertAsync(Guid id)
    {
        var concert = await _concertRepository.GetById(id);
        await _concertRepository.Delete(concert);
    }

    // public async Task<string> GenerateDetailedReportAsync(Guid id)
    // {
    //     var concert = await _concertRepository.GetById(id);
    //     var tickets = await _ticketRepository.Get(t => t.Event.Id == id);

    //     concert.GenerateReport(); 

    //     var revenue = tickets.Sum(t => t.Price);
    //     return $"Total Tickets Sold: {tickets.Count()}, Total Revenue: {revenue:C}";
    // }

    // tá comentado porque Event em Ticket tá comentado também porque eu tava testando se funcionava, depois lembrar de tirar

}