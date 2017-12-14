using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AlbumMeta.Models;
using System.Linq;

namespace AlbumMeta.Controllers
{
    [Route("api/artist")]
    public class ArtistController : Controller
    {
        private readonly ArtistContext _context;

        public ArtistController(ArtistContext context)
        {
            _context = context;            
        }

        [HttpGet]
        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public IActionResult GetById(long id)
        {
            var item = _context.Artists.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Artist item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Artists.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetArtist", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Artist item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var artist = _context.Artists.FirstOrDefault(t => t.Id == id);
            if (artist == null)
            {
                return NotFound();
            }
            
            artist.Name = item.Name;

            _context.Artists.Update(artist);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var artist = _context.Artists.FirstOrDefault(t => t.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}