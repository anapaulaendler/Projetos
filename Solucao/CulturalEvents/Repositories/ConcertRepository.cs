using CulturalEvents.Models;

namespace CulturalEvents.Repositories
{
    public class ConcertRepository : RepositoryBase<Concert>, IConcertRepository
    {

        public ConcertRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}