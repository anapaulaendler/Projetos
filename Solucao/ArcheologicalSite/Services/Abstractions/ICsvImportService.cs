using ArcheologicalSite.Models;

namespace ArcheologicalSite.Services
{
    public interface ICsvImportService
    {
        Task ProcessPeopleAsync(Stream stream);
        Task ProcessFossilsAsync(Stream fossilsStream);
        Task ProcessArtefactsAsync(Stream artefactsStream);
    }
}