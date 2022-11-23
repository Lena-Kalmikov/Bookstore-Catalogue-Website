namespace WebProjectLena.Models
{
    public class BookGenreJoin
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ImageName { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Description { get; set; }
        public string? GenreName { get; set; }
    }
}