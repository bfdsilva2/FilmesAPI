using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Insert a movie
    /// </summary>
    /// <param name="movieDto"></param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If the insertion was successful</response>
    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    /// <summary>
    /// Get all movies
    /// </summary>
    /// <param name="skip">Records to skip</param>
    /// <param name="take">Records to take</param>
    /// <returns>IEnumerable(ReadMovieDto)</returns>
    /// <response code="200">If successful</response>
    [HttpGet]
    public IEnumerable<ReadMovieDto> Movies([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? cinemaName = null)
    {
        if (cinemaName == null)
            return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take).ToList());
        else
            return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take).
                Where(movie => movie.Sections.Any(section => section.Cinema.Name.Contains(cinemaName))).ToList());
    }

    /// <summary>
    /// Get movie by Id
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">If successful</response>
    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(i => i.Id == id);
        if (movie == null)
            return NotFound();

        return Ok(_mapper.Map<ReadMovieDto>(movie));
    }

    /// <summary>
    /// Update movie
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="movieDto">Movie</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">No content</response>
    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(i => i.Id == id);
        if (movie == null)
            return NotFound();

        _mapper.Map(movieDto, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePatch(int id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(i => i.Id == id);
        if (movie == null)
            return NotFound();

        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
        patch.ApplyTo(movieToUpdate, ModelState);

        if (!TryValidateModel(movieToUpdate))
            return ValidationProblem(ModelState);

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id) 
    {
        var movie = _context.Movies.FirstOrDefault(i => i.Id == id);
        if (movie == null)
            return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }

}
