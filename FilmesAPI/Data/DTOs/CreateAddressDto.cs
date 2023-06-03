using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class CreateAddressDto
    {
        public string Street { get; set; }
       
        public int Number { get; set; }
    }
}