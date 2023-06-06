using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

        public ReadAddressDto Address { get; set; }

        //public int AddressId { get; set; }

        public ICollection<ReadSectionDto> Sections { get; set; }

        //public virtual ICollection<Section> Sections { get; set; }
    }
}