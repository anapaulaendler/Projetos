using CulturalEvents.Models;
using CulturalEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/exhibitions")]
public class ExhibitionController : ControllerBase
{
    private readonly IExhibitionService _exhibitionService;

    public ExhibitionController(IExhibitionService exhibitionService)
    {
        _exhibitionService = exhibitionService;
    }

    [HttpPost]
    public async Task<Exhibition> CreateExhibition(Exhibition exhibition)
    {
        await _exhibitionService.CreateExhibitionAsync(exhibition);
        return exhibition;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExhibitionById(Guid id)
    {
        try
        {
            var exhibition = await _exhibitionService.GetExhibitionByIdAsync(id);
            return Ok(exhibition);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Exhibition>> GetExhibitions()
    {
        var exhibitions = await _exhibitionService.GetAllExhibitionsAsync();
        return exhibitions;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExhibition(Guid id)
    {
        try
        {
            await _exhibitionService.DeleteExhibitionAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("report/{id}")]
    public async Task<string> GenerateExhibitionReport(Guid id)
    {
        var report = await _exhibitionService.GenerateDetailedReportAsync(id);
        return report;
    }

    [HttpPut("{id}")]
    public async Task<Exhibition> UpdateExhibition(Exhibition exhibition, Guid id)
    {
        await _exhibitionService.UpdateExhibitionAsync(exhibition, id);

        return exhibition;
    }
}
