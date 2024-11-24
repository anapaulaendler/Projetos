using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class ConcertService
{
    private readonly IConcertRepository _concertRepository;

    private ConcertService(IConcertRepository concertRepository)
    {
        _concertRepository = concertRepository;
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
}