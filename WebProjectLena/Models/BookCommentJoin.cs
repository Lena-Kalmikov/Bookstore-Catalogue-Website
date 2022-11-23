namespace WebProjectLena.Models
{
    public class BookCommentJoin
    {
        public int? BookId { get; set; }
        public int? CommentId { get; set; }
        public int? Count { get; set; }
        public string? Title { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
    }
}