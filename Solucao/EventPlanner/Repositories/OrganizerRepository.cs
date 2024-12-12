using EventPlanner.Context;
using EventPlanner.Models;

namespace EventPlanner.Repositories;

public class OrganizerRepository : RepositoryBase<Organizer>, IOrganizerRepository
{
    public OrganizerRepository(AppDbContext appContext) : base(appContext)
    {
    }
}
