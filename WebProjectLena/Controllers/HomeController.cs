using Microsoft.AspNetCore.Mvc;
using WebProjectLena.Repositories.Books;

namespace WebProjectLena.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var topCommentedBooks = _bookRepository.GetTopCommentedBooks();
            return View(topCommentedBooks);
        }
    }
}