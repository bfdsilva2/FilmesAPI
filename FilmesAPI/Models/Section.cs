using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Section
{
    [Key]
    [Required]
    public int Id { get; set; }
}
