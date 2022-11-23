using WebProjectLena.Data;
using WebProjectLena.Models;

namespace WebProjectLena.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private BooksCatalogueContext _context;
        public CommentRepository(BooksCatalogueContext context)
        {
            _context = context;
        }
        public IEnumerable<CommentModel> GetComments()
        {
            return _context.Comments!;
        }
        public void AddComment(CommentModel comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }
    }
}
