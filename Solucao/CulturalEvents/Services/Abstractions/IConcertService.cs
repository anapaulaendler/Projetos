using CulturalEvents.Models;

namespace CulturalEvents.Services
{
    public interface IConcertService
    {
        Task CreateConcertAsync(Concert concert);
        Task<IEnumerable<Concert>> GetAllConcertsAsync();
        Task<Concert> GetConcertByIdAsync(Guid id);
        Task UpdateConcertAsync(Concert concert, Guid id);
        Task DeleteConcertAsync(Guid id);
        Task<string> GenerateDetailedReportAsync(Guid id);
    }
}