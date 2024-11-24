using CulturalEvents.Models;

namespace CulturalEvents.Repositories
{
    public class ExhibitionRepository : RepositoryBase<Exhibition>, IExhibitionRepository
    {
        public ExhibitionRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}