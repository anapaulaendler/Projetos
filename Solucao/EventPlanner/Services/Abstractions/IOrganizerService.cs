using EventPlanner.Models;

namespace EventPlanner.Services;

public interface IOrganizerService
{
    Task<List<Organizer>> GetAllOrganizers();
    Task<Organizer> GetOrganizerById(Guid id);
    Task CreateOrganizer(Organizer organizer);
    Task<Organizer> UpdateOrganizer(Guid id, Organizer updatedOrganizer);
    Task DeleteOrganizer(Guid id);

}