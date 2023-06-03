using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class UpdateCinemaDto 
{ 
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
}
