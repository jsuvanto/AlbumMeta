namespace AlbumMeta.Models
{
    public class Album
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ArtistId { get; set; }
        public uint ReleaseYear { get; set; }
    }
}
