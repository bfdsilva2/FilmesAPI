using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class CreateMovieDto
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    [StringLength(50, ErrorMessage = "Max length is 50 characters")]
    public string Genre { get; set; }

    [Required]
    [Range(70, 500, ErrorMessage = "Duration must be in between 70 and 200")]
    public int Duration { get; set; }
}
