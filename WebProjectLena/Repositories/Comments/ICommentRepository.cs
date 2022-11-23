using WebProjectLena.Models;

namespace WebProjectLena.Repositories.Comments
{
    public interface ICommentRepository
    {
        IEnumerable<CommentModel> GetComments();
        void AddComment(CommentModel comment);
    }
}