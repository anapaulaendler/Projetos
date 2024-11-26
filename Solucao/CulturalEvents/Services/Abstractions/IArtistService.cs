using CulturalEvents.Models;

namespace CulturalEvents.Services
{
    public interface IArtistService
    {
        Task CreateArtistAsync(Artist artist);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(Guid id);
        Task<Artist> UpdateArtistAsync(Artist artist, Guid id);
        Task DeleteArtistAsync(Guid id);
        Task<string> DisplayArtistDetails(Guid id);
    }
}