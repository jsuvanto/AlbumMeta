using Microsoft.EntityFrameworkCore;

namespace AlbumMeta.Models
{
    public class AlbumContext : DbContext
    {
        public AlbumContext(DbContextOptions<AlbumContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }

    }
}