using CulturalEvents.Models;

namespace CulturalEvents.Repositories
{
    public class TheaterPlayRepository : RepositoryBase<TheaterPlay>, ITheaterPlayRepository
    {
        public TheaterPlayRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}