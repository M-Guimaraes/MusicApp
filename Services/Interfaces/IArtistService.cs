using MusicApp.DTOs;
using MusicApp.Models;

namespace MusicApp.Services.Interfaces;

public interface IArtistService
{
    Task<Response<List<Artist>>> GetAllArtistsAsync();
    Task<Response<Artist>> GetArtistByIdAsync(int id);
    Task<Response<Artist>> CreateArtistAsync(ArtistRequest artistRequest);
    Task<Response<Artist>> UpdateArtistAsync(int id, ArtistRequest artistRequest);
    Task<Response<bool>> DeleteArtistAsync(int id);
}
