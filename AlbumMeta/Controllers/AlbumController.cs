using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AlbumMeta.Models;

namespace AlbumMeta.Controllers
{
    [Route("api/album")]
    public class AlbumController : Controller
    {
        private readonly AlbumContext _albumContext;        

        public AlbumController(AlbumContext albumContext)
        {
            _albumContext = albumContext;
        }

        [HttpGet("search/{name}", Name = "SearchAlbum")]
        public IEnumerable<Album> SearchAlbum(string name)
        {
            var artists = _albumContext.Albums.Where(album => album.Name.ToLower().Contains(name.ToLower()));

            return artists.ToList();
        }

        [HttpGet]
        public IEnumerable<Album> GetAll()
        {
            return _albumContext.Albums.ToList();
        }

        [HttpGet("{id}", Name = "GetAlbum")]
        public IActionResult GetById(long id)
        {
            var item = _albumContext.Albums.FirstOrDefault(t => t.Id == id);
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

            _albumContext.Albums.Add(item);
            _albumContext.SaveChanges();            

            return CreatedAtRoute("GetAlbum", new { id = item.Id, name = item.Name, artistId = item.ArtistId, releaseYear = item.ReleaseYear }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Album item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var album = _albumContext.Albums.FirstOrDefault(t => t.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            album.Name = item.Name;
            album.ReleaseYear = item.ReleaseYear;
            album.ArtistId = item.ArtistId;

            _albumContext.Albums.Update(album);
            _albumContext.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var album = _albumContext.Albums.FirstOrDefault(t => t.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            _albumContext.Albums.Remove(album);
            _albumContext.SaveChanges();
            return new NoContentResult();
        }

        
    }
}