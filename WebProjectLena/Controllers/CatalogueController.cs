using Microsoft.AspNetCore.Mvc;
using WebProjectLena.Models;
using WebProjectLena.Repositories.Books;
using WebProjectLena.Repositories.Comments;
using WebProjectLena.Repositories.Genres;

namespace WebProjectLena.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreReposiroty _genreReposiroty;
        private readonly ICommentRepository _commentRepository;
        public CatalogueController(IBookRepository bookRepository,IGenreReposiroty genreReposiroty,ICommentRepository commentRepository)
        {
            _bookRepository = bookRepository;
            _genreReposiroty = genreReposiroty;
            _commentRepository = commentRepository;
        }
        
        public IActionResult Index(int GenreId = -1)
        {
            // no genre selected -> show all books:
            ViewBag.Books = _bookRepository.GetAllBooks();
            
            // genre selected -> show books in that genre:
            if (GenreId != -1)
                ViewBag.Books = _bookRepository.GetBooksByGenre(GenreId);

            var genres = _genreReposiroty.GetGenres();
            ViewBag.SelectedGenreId = GenreId;

            return View(genres);
        }
        
        public IActionResult Details(int id)
        {
            // shows book with all details by book id
            ViewBag.Book = _bookRepository.GetBookWithGenreName(id);

            // show comments for specific book by book id
            var comments = _bookRepository.GetCommentsForBook(id);

            return View(comments);
        }
        
        [HttpPost]
        public ActionResult AddCommentToDB([FromBody] CommentModel newComment)
        {
            // uses data from view (json provides the comment string, the id is set automatically)
            // and then uses it as a parameter in the function below
            _commentRepository.AddComment(newComment);
            return Json(new { Result = "Success" });
        }
    }
}