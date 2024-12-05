using ArcheologicalSite.Context;
using ArcheologicalSite.Models;

namespace ArcheologicalSite.Repositories
{
    public class FossilRepository : RepositoryBase<Fossil>, IFossilRepository
    {
        public FossilRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}