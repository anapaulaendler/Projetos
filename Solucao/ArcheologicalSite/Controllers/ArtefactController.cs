using ArcheologicalSite.Models;
using ArcheologicalSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/artefacts")]
public class ArtefactController : ControllerBase
{
    private readonly IArtefactService _artefactService;

    public ArtefactController(IArtefactService artefactService)
    {
        _artefactService = artefactService;
    }

    [HttpPost]
    public async Task<Artefact> CreateArtefact(Artefact artefact)
    {
        await _artefactService.CreateArtefactAsync(artefact);
        return artefact;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArtefactById(Guid id)
    {
        try
        {
            var artefact = await _artefactService.GetArtefactByIdAsync(id);
            return Ok(artefact);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Artefact>> GetArtefacts()
    {
        var artefacts = await _artefactService.GetAllArtefactsAsync();
        return artefacts;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtefact(Guid id)
    {
        try
        {
            await _artefactService.DeleteArtefactAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<Artefact> UpdateArtefact(Artefact artefact, Guid id)
    {
        await _artefactService.UpdateArtefactAsync(artefact, id);

        return artefact;
    }
}