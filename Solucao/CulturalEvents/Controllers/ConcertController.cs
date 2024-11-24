using CulturalEvents.Models;
using CulturalEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/concerts")]
public class ConcertController : ControllerBase
{
    private readonly ConcertService _concertService;

    public ConcertController(ConcertService concertService)
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

    
}
