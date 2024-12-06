using ArcheologicalSite.Models;

namespace ArcheologicalSite.Services
{
    public interface IArcheologistService
    {
        Task CreateArcheologistAsync(Archeologist archeologist);
        Task<IEnumerable<Archeologist>> GetAllArcheologistsAsync();
        Task<Archeologist> GetArcheologistByIdAsync(Guid id);
        Task<Archeologist> UpdateArcheologistAsync(Archeologist archeologist, Guid id);
        Task DeleteArcheologistAsync(Guid id);
    }
}