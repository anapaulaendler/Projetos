using ArcheologicalSite.Context;
using ArcheologicalSite.Models;

namespace ArcheologicalSite.Repositories
{
    public class EducationRepository : RepositoryBase<Education>, IEducationRepository
    {
        public EducationRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}