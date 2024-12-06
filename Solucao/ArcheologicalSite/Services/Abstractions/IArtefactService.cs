using ArcheologicalSite.Models;

namespace ArcheologicalSite.Services
{
    public interface IArtefactService
    {
        Task CreateArtefactAsync(Artefact artefact);
        Task<IEnumerable<Artefact>> GetAllArtefactsAsync();
        Task<Artefact> GetArtefactByIdAsync(Guid id);
        Task<Artefact> UpdateArtefactAsync(Artefact artefact, Guid id);
        Task DeleteArtefactAsync(Guid id);
    }
}