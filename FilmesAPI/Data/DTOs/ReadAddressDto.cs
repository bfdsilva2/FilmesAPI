using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class ReadAddressDto
    {
        public  int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        public ICollection<ReadCinemaDto> Cinemas { get; set; }

    }
}