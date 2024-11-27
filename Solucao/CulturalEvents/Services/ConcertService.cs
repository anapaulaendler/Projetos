using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class ConcertService : IConcertService
{

    private readonly IConcertRepository _concertRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IArtistRepository _artistRepository;

    public ConcertService(IConcertRepository concertRepository, ITicketRepository ticketRepository, IArtistRepository artistRepository)
    {
        _concertRepository = concertRepository;
        _ticketRepository = ticketRepository;
        _artistRepository = artistRepository;
    }

    public async Task CreateConcertAsync(Concert concert)
    {
        concert.Artist = await _artistRepository.GetById(concert.ArtistId);
        concert.CalculateFee();
        
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

    public async Task UpdateConcertAsync(Concert concert, Guid id)
    {
        await _concertRepository.Update(concert, id);
    }

    public async Task DeleteConcertAsync(Guid id)
    {
        var concert = await _concertRepository.GetById(id);
        await _concertRepository.Delete(concert);
    }

    public async Task<string> GenerateDetailedReportAsync(Guid id)
    {
        var concert = await _concertRepository.GetById(id);
        var tickets = await _ticketRepository.Get(t => t.EventId == id);

        concert.GenerateReport(); 

        var revenue = tickets.Sum(t => t.Price);
        return $"Total Tickets Sold: {tickets.Count()}, Total Revenue: {revenue:C}";
    }
}