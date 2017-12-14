using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AlbumMeta.Models;
using System.Linq;

namespace AlbumMeta.Controllers
{
    [Route("api/artist")]
    public class ArtistController : Controller
    {
        private readonly ArtistContext _artistContext;

        public ArtistController(ArtistContext artistContext)
        {
            _artistContext = artistContext;            
        }
                
        [HttpGet("search/{name}", Name = "SearchArtist")]
        public IEnumerable<Artist> SearchArtist(string name)
        {
            var artists = _artistContext.Artists.Where(artist => artist.Name.ToLower().Contains(name.ToLower()));
            return artists.ToList();
        }

        [HttpGet]
        public IEnumerable<Artist> GetAll()
        {
            return _artistContext.Artists.ToList();
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public IActionResult GetById(long id)
        {
            var item = _artistContext.Artists.FirstOrDefault(t => t.Id == id);
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

            _artistContext.Artists.Add(item);
            _artistContext.SaveChanges();

            return CreatedAtRoute("GetArtist", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Artist item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var artist = _artistContext.Artists.FirstOrDefault(t => t.Id == id);
            if (artist == null)
            {
                return NotFound();
            }
            
            artist.Name = item.Name;

            _artistContext.Artists.Update(artist);
            _artistContext.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var artist = _artistContext.Artists.FirstOrDefault(t => t.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            _artistContext.Artists.Remove(artist);
            _artistContext.SaveChanges();
            return new NoContentResult();
        }
    }
}