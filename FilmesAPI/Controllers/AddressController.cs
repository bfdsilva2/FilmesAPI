using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.Loader;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AddressController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, addressDto);

        }

        [HttpGet]
        public IEnumerable<ReadAddressDto> GetAddresses()
        {
            return _mapper.Map<List<ReadAddressDto>>(_context.Addresses.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            var address = _context.Cinemas.FirstOrDefault(i => i.Id == id);
            if (address == null)
                return NotFound();

            return Ok(_mapper.Map<ReadAddressDto>(address));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
        {
            Address address = _context.Addresses.FirstOrDefault(i => i.Id == id);

            if (address == null)
                return NotFound();

            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(i => i.Id == id);
            if (address == null)
                return NotFound();

            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }

    }
}