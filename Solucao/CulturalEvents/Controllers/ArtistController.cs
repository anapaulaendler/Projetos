using CulturalEvents.Models;
using CulturalEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulturalEvents.Controllers;

[ApiController]
[Route("api/artists")]
public class ArtistController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpPost]
    public async Task<Artist> CreateArtist(Artist artist)
    {
        await _artistService.CreateArtistAsync(artist);
        return artist;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArtistById(Guid id)
    {
        try
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            return Ok(artist);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<Artist>> GetArtists()
    {
        var artists = await _artistService.GetAllArtistsAsync();
        return artists;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtist(Guid id)
    {
        try
        {
            await _artistService.DeleteArtistAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("details/{id}")]
    public async Task<string> DisplayArtistDetails(Guid id)
    {
        var details = await _artistService.DisplayArtistDetails(id);
        return details;
    }

    [HttpPut("{id}")]
    public async Task<Artist> UpdateArtist(Artist artist, Guid id)
    {
        await _artistService.UpdateArtistAsync(artist, id);

        return artist;
    }
}
