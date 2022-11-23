using WebProjectLena.Data;
using WebProjectLena.Models;
using WebProjectLena.Models.QueryHelpers;

namespace WebProjectLena.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksCatalogueContext _context;
        public BookRepository(BooksCatalogueContext context)
        {
            _context = context;
        }
        public BookModel GetBook(int bookId)
        {
            var book = _context.Books!.Single(m => m.BookId == bookId);
            return book;
        }
        public IEnumerable<BookModel> GetAllBooks()
        {
            return _context.Books!;
        }
        public void AddBook(BookModel book)
        {
            _context.Books!.Add(book);
            _context.SaveChanges();
        }
        public void EditBook(int id, BookModel editedBook)
        {
            var bookInDb = _context.Books!.Single(m => m.BookId == id);
            bookInDb.GenreId     =  editedBook.GenreId;
            bookInDb.ReleaseYear =  editedBook.ReleaseYear;
            bookInDb.Title       =  editedBook.Title;
            bookInDb.Description =  editedBook.Description;
            bookInDb.Author      =  editedBook.Author;
            bookInDb.ImageName   =  editedBook.ImageName;
            bookInDb.Description =  editedBook.Description;
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = _context.Books!.Single(m => m.BookId == id);
            _context.Books!.Remove(book);
            _context.SaveChanges();
        }

        // using sql queries to retireve data instead of linq
        public List<BookCommentJoin> GetTopCommentedBooks()
        {
            string query = "SELECT " +
                                "TOP 2 " +
                                "COUNT(Comments.CommentId)," +
                                "Books.BookId," +
                                "Books.Title," +
                                "Books.ImageName," +
                                "Books.Description\r\n" +
                           "FROM " +
                                "Books\r\n" +
                           "JOIN " +
                                "Comments\r\n" +
                           "ON " +
                                "Books.BookId = Comments.BookId\r\n" +
                           "GROUP BY " +
                                "Books.BookId," +
                                "Books.Title," +
                                "Books.ImageName," +
                                "Books.Description\r\n" +
                           "ORDER BY " +
                                "1 DESC";

            var results = Helper.RawSqlQuery
            (
                query,
                item => new BookCommentJoin
                {
                    Count       =  (int)item[0],
                    BookId      =  (int)item[1],
                    Title       =  (string)item[2],
                    ImageName   =  (string)item[3],
                    Description =  (string)item[4]
                },
                _context
            );
            return results;
        }
        public List<BookCommentJoin> GetCommentsForBook(int bookId)
        {
            string query = "SELECT " +
                                "Comment " +
                           "FROM " +
                                "Comments\r\n " +
                           "JOIN " +
                                "Books\r\n " +
                            "ON " +
                                "Books.BookId = comments.BookId\r\n " +
                           "WHERE " +
                                $"comments.BookId = {bookId}";

            var results = Helper.RawSqlQuery
            (
                query,
                item => new BookCommentJoin
                {
                    Comment = (string)item[0],
                },
                _context
            );
            return results;
        }
        public List<BookGenreJoin> GetBooksByGenre(int genreId)
        {
            string query = "SELECT " +
                                "Books.BookId, " +
                                "Books.GenreId, " +
                                "Books.Title, " +
                                "Books.ImageName\r\n " +
                           "FROM " +
                                "Books\r\n " +
                           "WHERE " +
                                $"Books.GenreId = {genreId}";

            var results = Helper.RawSqlQuery
            (
                query,
                item => new BookGenreJoin
                {
                    BookId    =  (int)item[0],
                    GenreId   =  (int)item[1],
                    Title     =  (string)item[2],
                    ImageName =  (string)item[3],
                },
                _context
            );
            return results;
        }
        public BookGenreJoin GetBookWithGenreName(int bookId)
        {
            string query = "SELECT " +
                                "Books.Title, " +
                                "Books.Author, " +
                                "Books.ReleaseYear, " +
                                "Genres.GenreName, " +
                                "Books.Description, " +
                                "Books.ImageName\r\n " +
                           "FROM " +
                                "Books\r\n " +
                           "JOIN " +
                                "Genres\r\n " +
                           "ON " +
                                "Books.GenreId = Genres.GenreId\r\n " +
                           "WHERE " +
                                $"Books.BookId = {bookId}";

            var results = Helper.RawSqlQuery
            (
                query,
                item => new BookGenreJoin
                {
                    Title       =  (string)item[0],
                    Author      =  (string)item[1],
                    ReleaseYear =  (int)item[2],
                    GenreName   =  (string)item[3],
                    Description =  (string)item[4],
                    ImageName   =  (string)item[5],
                },
                _context
            );

            BookGenreJoin book = results[0];
            book.BookId = bookId;

            return book;
        }
    }
}