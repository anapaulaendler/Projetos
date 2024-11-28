using CulturalEvents.Models;
using CulturalEvents.Repositories;

namespace CulturalEvents.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artistRepository;

    public ArtistService(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }
    public async Task CreateArtistAsync(Artist artist)
    {
        await _artistRepository.AddAsync(artist);
    }

    public async Task DeleteArtistAsync(Guid id)
    {
        var artist = await _artistRepository.GetById(id);
        await _artistRepository.Delete(artist);
    }

    public async Task<string> DisplayArtistDetails(Guid id)
    {
        var artist = await _artistRepository.GetById(id);
        return artist.DisplayDetails();
    }

    public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
    {
        return await _artistRepository.Get();
    }

    public async Task<Artist> GetArtistByIdAsync(Guid id)
    {
        var artist = await _artistRepository.GetById(id);
        return artist;
    }

    public async Task<Artist> UpdateArtistAsync(Artist updatedArtist, Guid id)
    {
        var artist = await GetArtistByIdAsync(id);

        artist.Name = updatedArtist.Name;
        artist.Email = updatedArtist.Email;
        artist.Speciality = updatedArtist.Speciality;

        await _artistRepository.Update(artist);
        
        return artist;
    }
}