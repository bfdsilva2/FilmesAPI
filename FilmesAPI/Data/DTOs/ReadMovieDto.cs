using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class ReadMovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }    
    public string Genre { get; set; }    
    public int Duration { get; set; }
    public DateTime AccessTime { get; set; } = DateTime.Now;
    
    public ICollection<ReadSectionDto> Sections { get; set; }
    
}
