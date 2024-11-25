using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class ConcertService : IConcertService
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

    async Task<string> IConcertService.GenerateDetailedReportAsync(Guid id)
    {
        var concert = await _concertRepository.GetById(id);
        var tickets = await _ticketRepository.Get(t => t.Event!.Id == id);

        concert.GenerateReport(); 

        var revenue = tickets.Sum(t => t.Price);
        return $"Total Tickets Sold: {tickets.Count()}, Total Revenue: {revenue:C}";
    }
}