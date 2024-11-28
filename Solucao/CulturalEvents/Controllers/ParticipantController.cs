using CulturalEvents.Models;
using CulturalEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/participants")]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _participantService;

    public ParticipantController(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpPost]
    public async Task<Participant> CreateParticipant(Participant participant)
    {
        await _participantService.CreateParticipantAsync(participant);
        return participant;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetParticipantById(Guid id)
    {
        try
        {
            var participant = await _participantService.GetParticipantByIdAsync(id);
            return Ok(participant);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipant(Guid id)
    {
        try
        {
            await _participantService.DeleteParticipantAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("details/{id}")]
    public async Task<string> DisplayParticipantDetails(Guid id)
    {
        var details = await _participantService.DisplayParticipantDetails(id);
        return details;
    }

    [HttpPut("{id}")]
    public async Task<Participant> UpdateParticipant(Participant participant, Guid id)
    {
        await _participantService.UpdateParticipantAsync(participant, id);

        return participant;
    }
}
