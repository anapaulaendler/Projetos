using CulturalEvents.Models;

namespace CulturalEvents.Repositories
{
    public class ParticipantRepository : RepositoryBase<Participant>, IParticipantRepository
    {

        public ParticipantRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}