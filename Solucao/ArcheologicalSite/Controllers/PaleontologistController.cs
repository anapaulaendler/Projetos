using ArcheologicalSite.Models;
using ArcheologicalSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/paleontologists")]
public class PaleontologistController : ControllerBase
{
    private readonly IPaleontologistService _paleontologistService;

    public PaleontologistController(IPaleontologistService paleontologistService)
    {
        _paleontologistService = paleontologistService;
    }

    [HttpPost]
    public async Task<Paleontologist> CreatePaleontologist(Paleontologist paleontologist)
    {
        await _paleontologistService.CreatePaleontologistAsync(paleontologist);
        return paleontologist;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaleontologistById(Guid id)
    {
        try
        {
            var paleontologist = await _paleontologistService.GetPaleontologistByIdAsync(id);
            return Ok(paleontologist);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Paleontologist>> GetPaleontologists()
    {
        var paleontologists = await _paleontologistService.GetAllPaleontologistsAsync();
        return paleontologists;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaleontologist(Guid id)
    {
        try
        {
            await _paleontologistService.DeletePaleontologistAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<Paleontologist> UpdatePaleontologist(Paleontologist paleontologist, Guid id)
    {
        await _paleontologistService.UpdatePaleontologistAsync(paleontologist, id);

        return paleontologist;
    }
}