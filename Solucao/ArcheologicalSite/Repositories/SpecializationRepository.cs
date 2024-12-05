using ArcheologicalSite.Context;
using ArcheologicalSite.Models;

namespace ArcheologicalSite.Repositories
{
    public class SpecializationRepository : RepositoryBase<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}