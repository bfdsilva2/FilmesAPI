using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Section
{
    public int? MovieId { get; set; }
    public virtual Movie Movie { get; set; }   
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}
