using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SectionController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public SectionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSection([FromBody] CreateSectionDto sectionDto)
        {
            Section section = _mapper.Map<Section>(sectionDto);
            _context.Sections.Add(section);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSectionById), new { Id = section.Id }, sectionDto);

        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> GetSections()
        {
            return _mapper.Map<List<ReadSectionDto>>(_context.Sections.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetSectionById(int id)
        {
            var section = _context.Sections.FirstOrDefault(i => i.Id == id);
            if (section == null)
                return NotFound();

            return Ok(_mapper.Map<ReadSectionDto>(section));
        }

        /*
        [HttpPut("{id}")]
        public IActionResult UpdateSection(int id, [FromBody] UpdateCinemaDto ectionDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(i => i.Id == id);

            if (cinema == null)
                return NotFound();

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }
        */
        [HttpDelete("{id}")]
        public IActionResult DeleteSection(int id)
        {
            Cinema section = _context.Sections.FirstOrDefault(i => i.Id == id);
            if (section == null)
                return NotFound();

            _context.Remove(section);
            _context.SaveChanges();
            return NoContent();
        }

    }
}