using ArcheologicalSite.Context;
using ArcheologicalSite.Models;

namespace ArcheologicalSite.Repositories
{
    public class ArcheologistRepository : RepositoryBase<Archeologist>, IArcheologistRepository
    {
        public ArcheologistRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}