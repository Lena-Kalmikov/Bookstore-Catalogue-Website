using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjectLena.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? ImageName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int? GenreId { get; set; }
    }
}