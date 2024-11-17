using Microsoft.EntityFrameworkCore;

using MusicApp.Data;
using MusicApp.Models;
using MusicApp.Repositories.Interfaces;

namespace MusicApp.Repositories;

public class ArtistRepository(AppDbContext context) : IArtistRepository
{

    public async Task<List<Artist>> GetAllArtistsAsync()
    {
        var artists = await context.Artists.ToListAsync();
        return artists;
    }

    public async Task<Artist?> GetArtistByIdAsync(int id)
    {
        var artist = await context.Artists.FindAsync(id);
        return artist;
    }

    public async Task<Artist> CreateArtistAsync(Artist artist)
    {
        context.Artists.Add(artist);
        await context.SaveChangesAsync();
        return artist;
    }

    public async Task<Artist> UpdateArtistAsync(Artist artist)
    {
        context.Artists.Update(artist);
        await context.SaveChangesAsync();
        return artist;
    }

    public async Task<bool> DeleteArtistAsync(int id)
    {
        var artist = await GetArtistByIdAsync(id);
        if (artist == null) return false;
        
        context.Artists.Remove(artist);
        await context.SaveChangesAsync();
        return true;
    }
}
