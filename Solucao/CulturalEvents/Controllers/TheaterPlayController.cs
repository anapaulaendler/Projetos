using CulturalEvents.Models;
using CulturalEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/theaterPlays")]
public class TheaterPlayController : ControllerBase
{
    private readonly ITheaterPlayService _theaterPlayService;

    public TheaterPlayController(ITheaterPlayService theaterPlayService)
    {
        _theaterPlayService = theaterPlayService;
    }

    [HttpPost]
    public async Task<TheaterPlay> CreateTheaterPlay(TheaterPlay theaterPlay)
    {
        await _theaterPlayService.CreateTheaterPlayAsync(theaterPlay);
        return theaterPlay;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTheaterPlayById(Guid id)
    {
        try
        {
            var theaterPlay = await _theaterPlayService.GetTheaterPlayByIdAsync(id);
            return Ok(theaterPlay);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<TheaterPlay>> GetTheaterPlays()
    {
        var theaterPlays = await _theaterPlayService.GetAllTheaterPlaysAsync();
        return theaterPlays;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTheaterPlay(Guid id)
    {
        try
        {
            await _theaterPlayService.DeleteTheaterPlayAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("report/{id}")]
    public async Task<string> GenerateTheaterPlayReport(Guid id)
    {
        var report = await _theaterPlayService.GenerateDetailedReportAsync(id);
        return report;
    }

    [HttpPut("{id}")]
    public async Task<TheaterPlay> UpdateTheaterPlay(TheaterPlay theaterPlay, Guid id)
    {
        await _theaterPlayService.UpdateTheaterPlayAsync(theaterPlay, id);

        return theaterPlay;
    }
}
