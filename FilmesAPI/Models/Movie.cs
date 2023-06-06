using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="Title is required")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Genre is required")]
    [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
    public string Genre { get; set; }
        
    [Required]
    [Range(70,500, ErrorMessage = "Duration must be in between 70 and 200")]
    public int Duration { get; set; }
    public virtual ICollection<Section> Sections { get; set; } 
}
