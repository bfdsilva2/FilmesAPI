using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class ReadSectionDto
    { 
        public int MovieId { get; set; }

        public int CinemaId { get; set; }

    }
}