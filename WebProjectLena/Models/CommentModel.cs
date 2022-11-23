using System.ComponentModel.DataAnnotations;

namespace WebProjectLena.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string? Comment { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
