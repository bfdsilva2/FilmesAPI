using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace FilmesAPI.Models
{
    public class Address
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int Number { get; set; }

 
        public virtual Cinema Cinema { get; set; }


    }
}
