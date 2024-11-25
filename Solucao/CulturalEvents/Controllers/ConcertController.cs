using CulturalEvents.Models;
using CulturalEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/concerts")]
public class ConcertController : ControllerBase
{
    private readonly IConcertService _concertService;

    public ConcertController(IConcertService concertService)
    {
        _concertService = concertService;
    }

    [HttpPut]
    public async Task<Concert> CreateConcert(Concert concert)
    {
        await _concertService.CreateConcertAsync(concert);
        return concert;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetConcertById(Guid id)
    {
        try
        {
            var concert = await _concertService.GetConcertByIdAsync(id);
            return Ok(concert);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Concert>> GetConcerts()
    {
        var concerts = await _concertService.GetAllConcertsAsync();
        return concerts;
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteConcert(Guid id)
    {
        try
        {
            await _concertService.DeleteConcertAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("report/{id}")]
    public async Task<string> GenerateConcertReport(Guid id)
    {
        var report = await _concertService.GenerateDetailedReportAsync(id);
        return report;
    }
}
