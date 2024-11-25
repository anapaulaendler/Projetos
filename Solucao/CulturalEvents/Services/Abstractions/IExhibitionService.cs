using CulturalEvents.Models;

namespace CulturalEvents.Services
{
    public interface IExhibitionService
    {
        Task CreateExhibitionAsync(Exhibition exhibition);
        Task<IEnumerable<Exhibition>> GetAllExhibitionsAsync();
        Task<Exhibition> GetExhibitionByIdAsync(Guid id);
        Task UpdateExhibitionAsync(Exhibition exhibition);
        Task DeleteExhibitionAsync(Guid id);
        Task<string> GenerateDetailedReportAsync(Guid id);
    }
}