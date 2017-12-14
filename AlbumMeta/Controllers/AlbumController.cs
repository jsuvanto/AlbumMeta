using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AlbumMeta.Models;

namespace AlbumMeta.Controllers
{
    [Route("api/album")]
    public class AlbumController : Controller
    {
        private readonly AlbumContext _context;

        public AlbumController(AlbumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Album> GetAll()
        {
            return _context.Albums.ToList();
        }

        [HttpGet("{id}", Name = "GetAlbum")]
        public IActionResult GetById(long id)
        {
            var item = _context.Albums.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Album item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Albums.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("Album", new { id = item.Id, name = item.Name, artistId = item.ArtistId, releaseYear = item.ReleaseYear }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Album item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var album = _context.Albums.FirstOrDefault(t => t.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            album.Name = item.Name;
            album.ReleaseYear = item.ReleaseYear;
            album.ArtistId = item.ArtistId;

            _context.Albums.Update(album);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var album = _context.Albums.FirstOrDefault(t => t.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}