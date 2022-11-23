using WebProjectLena.Models;

namespace WebProjectLena.Repositories.Books
{
    public interface IBookRepository
    {
        IEnumerable<BookModel> GetAllBooks();
        BookModel GetBook(int bookId);
        void AddBook(BookModel book);
        void EditBook(int id, BookModel book);
        void DeleteBook(int id);
        List<BookCommentJoin> GetTopCommentedBooks();
        List<BookCommentJoin> GetCommentsForBook(int bookId);
        BookGenreJoin GetBookWithGenreName(int bookId);
        List<BookGenreJoin> GetBooksByGenre(int genreId);
    }
}
