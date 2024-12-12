using EventPlanner.Models;
using EventPlanner.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers;

[ApiController]
[Route("organizer")]
public class OrganizerController : ControllerBase
{
    private readonly IOrganizerService _organizerService;

    public OrganizerController(IOrganizerService organizerService)
    {
        _organizerService = organizerService;
    }

    [HttpPost]
    public async Task<Organizer> CreateOrganizer(Organizer organizer)
    {
        await _organizerService.CreateOrganizer(organizer);
        return organizer;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrganizerById(Guid id)
    {
        try
        {
            var organizer = await _organizerService.GetOrganizerById(id);
            return Ok(organizer);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<List<Organizer>> GetOrganizers()
    {
        var organizers = await _organizerService.GetAllOrganizers();
        return organizers;
    }

    [HttpPut("{id}")]
    public async Task<Organizer> UpdateOrganizer(Guid id, Organizer organizer)
    {
        await _organizerService.UpdateOrganizer(id, organizer);

        return organizer;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrganizer(Guid id)
    {
        try
        {
            await _organizerService.DeleteOrganizer(id);
            return NoContent();
        }
        catch
        {
            return NotFound();
        }
    }
}