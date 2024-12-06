using ArcheologicalSite.Models;

namespace ArcheologicalSite.Services
{
    public interface IPaleontologistService
    {
        Task CreatePaleontologistAsync(Paleontologist paleontologist);
        Task<IEnumerable<Paleontologist>> GetAllPaleontologistsAsync();
        Task<Paleontologist> GetPaleontologistByIdAsync(Guid id);
        Task<Paleontologist> UpdatePaleontologistAsync(Paleontologist paleontologist, Guid id);
        Task DeletePaleontologistAsync(Guid id);
    }
}