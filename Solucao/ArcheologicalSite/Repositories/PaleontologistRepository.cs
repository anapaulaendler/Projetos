using ArcheologicalSite.Context;
using ArcheologicalSite.Models;

namespace ArcheologicalSite.Repositories
{
    public class PaleontologistRepository : RepositoryBase<Paleontologist>, IPaleontologistRepository
    {
        public PaleontologistRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}