using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class ReadMovieDto
{
    public string Title { get; set; }    
    public string Genre { get; set; }    
    public int Duration { get; set; }
    public DateTime AccessTime { get; set; } = DateTime.Now;
}
