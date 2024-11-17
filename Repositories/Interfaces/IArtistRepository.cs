using MusicApp.Models;

namespace MusicApp.Repositories.Interfaces;

public interface IArtistRepository
{
    Task<List<Artist>> GetAllArtistsAsync();
    Task<Artist?> GetArtistByIdAsync(int id);
    Task<Artist> CreateArtistAsync(Artist artist);
    Task<Artist> UpdateArtistAsync(Artist artist);
    Task<bool> DeleteArtistAsync(int id);
}
