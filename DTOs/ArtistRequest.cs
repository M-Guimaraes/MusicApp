using System.ComponentModel.DataAnnotations;

namespace MusicApp.DTOs;

public class ArtistRequest
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Genre is required")]
    public string Genre { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; } = string.Empty;
}
