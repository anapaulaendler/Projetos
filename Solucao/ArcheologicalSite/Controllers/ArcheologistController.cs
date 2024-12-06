using ArcheologicalSite.Models;
using ArcheologicalSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/archeologists")]
public class ArcheologistController : ControllerBase
{
    private readonly IArcheologistService _archeologistService;

    public ArcheologistController(IArcheologistService archeologistService)
    {
        _archeologistService = archeologistService;
    }

    [HttpPost]
    public async Task<Archeologist> CreateArcheologist(Archeologist archeologist)
    {
        await _archeologistService.CreateArcheologistAsync(archeologist);
        return archeologist;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArcheologistById(Guid id)
    {
        try
        {
            var archeologist = await _archeologistService.GetArcheologistByIdAsync(id);
            return Ok(archeologist);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Archeologist>> GetArcheologists()
    {
        var archeologists = await _archeologistService.GetAllArcheologistsAsync();
        return archeologists;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArcheologist(Guid id)
    {
        try
        {
            await _archeologistService.DeleteArcheologistAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<Archeologist> UpdateArcheologist(Archeologist archeologist, Guid id)
    {
        await _archeologistService.UpdateArcheologistAsync(archeologist, id);

        return archeologist;
    }
}