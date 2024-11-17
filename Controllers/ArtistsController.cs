using Microsoft.AspNetCore.Mvc;

using MusicApp.DTOs;
using MusicApp.Services.Interfaces;

namespace MusicApp.Controllers;

[ApiController]
[Route("api/artists")]
public class ArtistsController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistsController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllArtistsAsync()
    {
        var artists = await _artistService.GetAllArtistsAsync();
        return Ok(artists);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetArtistByIdAsync(int id)
    {
        var artist = await _artistService.GetArtistByIdAsync(id);
        return Ok(artist);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateArtistAsync([FromBody] ArtistRequest artistRequest)
    {
        var artist = await _artistService.CreateArtistAsync(artistRequest);
        return Ok(artist);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArtistAsync([FromBody] ArtistRequest artistRequest, int id)
    {
        var artist = await _artistService.UpdateArtistAsync(id, artistRequest);
        return Ok(artist);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtistAsync(int id)
    {
        var artist = await _artistService.DeleteArtistAsync(id);
        return Ok(artist);
    }
    
}
