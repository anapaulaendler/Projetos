using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class TheaterPlayService : ITheaterPlayService
{
    private readonly ITheaterPlayRepository _theaterPlayRepository;
    private readonly ITicketRepository _ticketRepository;

    private TheaterPlayService(ITheaterPlayRepository theaterPlayRepository, ITicketRepository ticketRepository)
    {
        _theaterPlayRepository = theaterPlayRepository;
        _ticketRepository = ticketRepository;
    }

    public async Task CreateTheaterPlayAsync(TheaterPlay theaterPlay)
    {
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

    public async Task UpdateTheaterPlayAsync(TheaterPlay theaterPlay)
    {
        await _theaterPlayRepository.Update(theaterPlay);
    }

    public async Task DeleteTheaterPlayAsync(Guid id)
    {
        var theaterPlay = await _theaterPlayRepository.GetById(id);
        await _theaterPlayRepository.Delete(theaterPlay);
    }

    public async Task<string> GenerateDetailedReportAsync(Guid id)
    {
        var theaterPlay = await _theaterPlayRepository.GetById(id);
        var tickets = await _ticketRepository.Get(t => t.Event!.Id == id);
        // pode dar erro aqui

        theaterPlay.GenerateReport(); 

        var revenue = tickets.Sum(t => t.Price);
        return $"Total Tickets Sold: {tickets.Count()}, Total Revenue: {revenue:C}";
    }
}