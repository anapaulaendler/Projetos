using ArcheologicalSite.Models;

namespace ArcheologicalSite.Services
{
    public interface ICsvImportService
    {
        Task ProcessPeopleAsync(Stream stream);
        Task ProcessItemsAsync(Stream fossilsStream, Stream artefactsStream);
    }
}