using ArcheologicalSite.Models;

namespace ArcheologicalSite.Services
{
    public interface ICsvImportService
    {
        Task ProcessPeopleAsync(Stream stream);
        Task ProcessFossilsAsync(string fossilsStream);
        Task ProcessArtefactsAsync(string artefactsStream);
    }
}