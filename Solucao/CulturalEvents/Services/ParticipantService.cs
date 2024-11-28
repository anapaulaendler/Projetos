using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class ParticipantService : IParticipantService
{
    private readonly IParticipantRepository _participantRepository;
    public ParticipantService(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }
    public async Task CreateParticipantAsync(Participant participant)
    {
        await _participantRepository.AddAsync(participant);
    }

    public async Task DeleteParticipantAsync(Guid id)
    {
        var participant = await _participantRepository.GetById(id);
        await _participantRepository.Delete(participant);
    }

    public async Task<string> DisplayParticipantDetails(Guid id)
    {
        var participant = await _participantRepository.GetById(id);
        return participant.DisplayDetails();
    }

    public async Task<Participant> GetParticipantByIdAsync(Guid id)
    {
        var participant = await _participantRepository.GetById(id);
        return participant;
    }

    public async Task UpdateParticipantAsync(Participant updatedParticipant, Guid id)
    {
        var participant = await GetParticipantByIdAsync(id);

        participant.Name = updatedParticipant.Name;
        participant.Email = updatedParticipant.Email;

        await _participantRepository.Update(participant);
    }
}