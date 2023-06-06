using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Section>().HasKey(section => new { section.MovieId, section.CinemaId });
        
        modelBuilder.Entity<Section>()
            .HasOne(section => section.Cinema)
            .WithMany(movie => movie.Sections)
            .HasForeignKey(section => section.CinemaId);

        modelBuilder.Entity<Section>()
            .HasOne(section => section.Movie)
            .WithMany(movie => movie.Sections)
            .HasForeignKey(section => section.MovieId);

        modelBuilder.Entity<Address>()
            .HasOne(address => address.Cinema)
            .WithOne(cinema => cinema.Address)
            .OnDelete(DeleteBehavior.Restrict);

    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public DbSet<Section> Sections { get; set; }
}
