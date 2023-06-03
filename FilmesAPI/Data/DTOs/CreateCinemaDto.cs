using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public int AddressId { get; set; } 

    }
}