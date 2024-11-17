using MusicApp.DTOs;
using MusicApp.Models;
using MusicApp.Repositories.Interfaces;
using MusicApp.Services.Interfaces;

namespace MusicApp.Services;

public class ArtistService : IArtistService
{

    private readonly IArtistRepository _artistRepository;

    public ArtistService(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }
    
    public async Task<Response<List<Artist>>> GetAllArtistsAsync()
    {
        var response = new Response<List<Artist>>();
        var artists = await _artistRepository.GetAllArtistsAsync();
        
        response.Data = artists;

        return response;
    }

    public  async Task<Response<Artist>> GetArtistByIdAsync(int id)
    {
        var response = new Response<Artist>();
        var artist = await _artistRepository.GetArtistByIdAsync(id);

        if (artist == null) 
        {
            response.Success = false;
            response.Message = "Artist not found";
            return response;
        }
        
        response.Data = artist;
        return response;
    }

    public async Task<Response<Artist>> CreateArtistAsync(ArtistRequest artistRequest)
    {
        var response = new Response<Artist>();
        var artist = new Artist {
            Name = artistRequest.Name,
            Genre = artistRequest.Genre,
            Country = artistRequest.Country,
        };
        
        var createdArtist = await _artistRepository.CreateArtistAsync(artist);
        response.Data = createdArtist;
        return response;
    }

    public async Task<Response<Artist>> UpdateArtistAsync(int id, ArtistRequest artistRequest)
    {
        var response = new Response<Artist>();
        var artist = await _artistRepository.GetArtistByIdAsync(id);

        if (artist == null) {
            response.Success = false;
            response.Message = "Artist not found";
            return response;
        }
        
        artist.Name = artistRequest.Name;
        artist.Genre = artistRequest.Genre;
        artist.Country = artistRequest.Country;
        
        var updatedArtist = await _artistRepository.UpdateArtistAsync(artist);
        response.Data = updatedArtist;
        return response;
    }

    public async Task<Response<bool>> DeleteArtistAsync(int id)
    {
        var response = new Response<bool>();
        var deleted = await _artistRepository.DeleteArtistAsync(id);
        response.Data = deleted;
        return response;
    }
}
