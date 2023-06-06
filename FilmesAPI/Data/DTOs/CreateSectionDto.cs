using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class CreateSectionDto
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
    }
}