using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class TheaterPlayService : ITheaterPlayService
{
    private readonly ITheaterPlayRepository _theaterPlayRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IArtistRepository _artistRepository;


    public TheaterPlayService(ITheaterPlayRepository theaterPlayRepository, ITicketRepository ticketRepository, IArtistRepository artistRepository)
    {
        _theaterPlayRepository = theaterPlayRepository;
        _ticketRepository = ticketRepository;
        _artistRepository = artistRepository;
    }

    public async Task CreateTheaterPlayAsync(TheaterPlay theaterPlay)
    {
        theaterPlay.Artist = await _artistRepository.GetById(theaterPlay.ArtistId);
        theaterPlay.CalculateFee();

        await _theaterPlayRepository.AddAsync(theaterPlay);
    }

    public async Task<IEnumerable<TheaterPlay>> GetAllTheaterPlaysAsync()
    {
        return await _theaterPlayRepository.Get();
    }

    public async Task<TheaterPlay> GetTheaterPlayByIdAsync(Guid id)
    {
        return await _theaterPlayRepository.GetById(id);
    }

    public async Task UpdateTheaterPlayAsync(TheaterPlay theaterPlay, Guid id)
    {
        await _theaterPlayRepository.Update(theaterPlay, id);
    }

    public async Task DeleteTheaterPlayAsync(Guid id)
    {
        var theaterPlay = await _theaterPlayRepository.GetById(id);
        await _theaterPlayRepository.Delete(theaterPlay);
    }

    public async Task<string> GenerateDetailedReportAsync(Guid id)
    {
        var theaterPlay = await _theaterPlayRepository.GetById(id);
        var tickets = await _ticketRepository.Get(t => t.EventId == id);

        theaterPlay.GenerateReport(); 

        var revenue = tickets.Sum(t => t.Price);
        return $"Total Tickets Sold: {tickets.Count()}, Total Revenue: {revenue:C}";
    }
}