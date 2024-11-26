using CulturalEvents.Models;

namespace CulturalEvents.Services
{
    public interface ITheaterPlayService
    {
        Task CreateTheaterPlayAsync(TheaterPlay theaterPlay);
        Task<IEnumerable<TheaterPlay>> GetAllTheaterPlaysAsync();
        Task<TheaterPlay> GetTheaterPlayByIdAsync(Guid id);
        Task UpdateTheaterPlayAsync(TheaterPlay theaterPlay, Guid id);
        Task DeleteTheaterPlayAsync(Guid id);
        Task<string> GenerateDetailedReportAsync(Guid id);
    }
}