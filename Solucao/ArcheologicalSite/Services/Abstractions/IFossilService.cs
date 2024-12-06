using ArcheologicalSite.Models;

namespace ArcheologicalSite.Services
{
    public interface IFossilService
    {
        Task CreateFossilAsync(Fossil fossil);
        Task<IEnumerable<Fossil>> GetAllFossilsAsync();
        Task<Fossil> GetFossilByIdAsync(Guid id);
        Task<Fossil> UpdateFossilAsync(Fossil fossil, Guid id);
        Task DeleteFossilAsync(Guid id);
    }
}