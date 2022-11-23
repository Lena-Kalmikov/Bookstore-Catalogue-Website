using System.ComponentModel.DataAnnotations;

namespace WebProjectLena.Models
{
    public class GenreModel
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string? GenreName { get; set; }
    }
}
