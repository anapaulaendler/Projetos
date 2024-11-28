using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class ExhibitionService : IExhibitionService
{
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IArtistRepository _artistRepository;


    public ExhibitionService(IExhibitionRepository exhibitionRepository, ITicketRepository ticketRepository, IArtistRepository artistRepository)
    {
        _exhibitionRepository = exhibitionRepository;
        _ticketRepository = ticketRepository;
        _artistRepository = artistRepository;
    }

    public async Task CreateExhibitionAsync(Exhibition exhibition)
    {
        exhibition.Artist = await _artistRepository.GetById(exhibition.ArtistId);
        exhibition.CalculateFee();

        await _exhibitionRepository.AddAsync(exhibition);
    }

    public async Task<IEnumerable<Exhibition>> GetAllExhibitionsAsync()
    {
        return await _exhibitionRepository.Get();
    }

    public async Task<Exhibition> GetExhibitionByIdAsync(Guid id)
    {
        return await _exhibitionRepository.GetById(id);
    }

    public async Task UpdateExhibitionAsync(Exhibition updatedExhibition, Guid id)
    {
        var exhibition = await GetExhibitionByIdAsync(id);

        exhibition.Name = updatedExhibition.Name;
        exhibition.Date = updatedExhibition.Date;
        exhibition.Location = updatedExhibition.Location;
        exhibition.Capacity = updatedExhibition.Capacity;
        exhibition.Duration = updatedExhibition.Duration;

        await _exhibitionRepository.Update(exhibition);
    }

    public async Task DeleteExhibitionAsync(Guid id)
    {
        var exhibition = await _exhibitionRepository.GetById(id);
        await _exhibitionRepository.Delete(exhibition);
    }

    public async Task<string> GenerateDetailedReportAsync(Guid id)
    {
        var exhibition = await _exhibitionRepository.GetById(id);
        var tickets = await _ticketRepository.Get(t => t.EventId == id);

        exhibition.GenerateReport(); 

        var revenue = tickets.Sum(t => t.Price);
        return $"Total Tickets Sold: {tickets.Count()}, Total Revenue: {revenue:C}";
    }
}