using Microsoft.EntityFrameworkCore;

namespace AlbumMeta.Models
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

    }
}