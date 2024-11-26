using CulturalEvents.Models;

namespace CulturalEvents.Services
{
    public interface IParticipantService
    {
        Task CreateParticipantAsync(Participant participant);
        // Task<IEnumerable<Participant>> GetAllParticipantsAsync(Guid idE);
        Task<Participant> GetParticipantByIdAsync(Guid id);
        Task UpdateParticipantAsync(Participant participant, Guid id);
        Task DeleteParticipantAsync(Guid id);
        Task<string> DisplayParticipantDetails(Guid id);
    }
}