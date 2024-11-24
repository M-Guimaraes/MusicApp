using MusicApp.DTOs;
using MusicApp.Models;
using MusicApp.Repositories.Interfaces;
using MusicApp.Services.Interfaces;

namespace MusicApp.Services;

public class ArtistService(IArtistRepository artistRepository) : IArtistService
{

    public async Task<Response<List<Artist>>> GetAllArtistsAsync()
    {
        var response = new Response<List<Artist>>();
        var artists = await artistRepository.GetAllArtistsAsync();
        
        response.Data = artists;

        return response;
    }

    public  async Task<Response<Artist>> GetArtistByIdAsync(int id)
    {
        var response = new Response<Artist>();
        var artist = await artistRepository.GetArtistByIdAsync(id);

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
        
        var createdArtist = await artistRepository.CreateArtistAsync(artist);
        response.Data = createdArtist;
        return response;
    }

    public async Task<Response<Artist>> UpdateArtistAsync(int id, ArtistRequest artistRequest)
    {
        var response = new Response<Artist>();
        var artist = await artistRepository.GetArtistByIdAsync(id);

        if (artist == null) {
            response.Success = false;
            response.Message = "Artist not found";
            return response;
        }
        
        artist.Name = artistRequest.Name;
        artist.Genre = artistRequest.Genre;
        artist.Country = artistRequest.Country;
        
        var updatedArtist = await artistRepository.UpdateArtistAsync(artist);
        response.Data = updatedArtist;
        return response;
    }

    public async Task<Response<bool>> DeleteArtistAsync(int id)
    {
        var response = new Response<bool>();
        var deleted = await artistRepository.DeleteArtistAsync(id);
        response.Data = deleted;
        return response;
    }
}
