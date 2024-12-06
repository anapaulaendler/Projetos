using ArcheologicalSite.Models;
using ArcheologicalSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/fossils")]
public class FossilController : ControllerBase
{
    private readonly IFossilService _fossilService;

    public FossilController(IFossilService fossilService)
    {
        _fossilService = fossilService;
    }

    [HttpPost]
    public async Task<Fossil> CreateFossil(Fossil fossil)
    {
        await _fossilService.CreateFossilAsync(fossil);
        return fossil;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFossilById(Guid id)
    {
        try
        {
            var fossil = await _fossilService.GetFossilByIdAsync(id);
            return Ok(fossil);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Fossil>> GetFossils()
    {
        var fossils = await _fossilService.GetAllFossilsAsync();
        return fossils;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFossil(Guid id)
    {
        try
        {
            await _fossilService.DeleteFossilAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<Fossil> UpdateFossil(Fossil fossil, Guid id)
    {
        await _fossilService.UpdateFossilAsync(fossil, id);

        return fossil;
    }
}