using CulturalEvents.Models;

namespace CulturalEvents.Repositories
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {

        public ArtistRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}