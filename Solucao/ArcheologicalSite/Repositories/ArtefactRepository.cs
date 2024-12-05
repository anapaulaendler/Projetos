using ArcheologicalSite.Context;
using ArcheologicalSite.Models;

namespace ArcheologicalSite.Repositories
{
    public class ArtefactRepository : RepositoryBase<Artefact>, IArtefactRepository
    {
        public ArtefactRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}