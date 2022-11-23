using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProjectLena.Models;
using WebProjectLena.Repositories.Books;
using WebProjectLena.Repositories.Genres;

namespace WebProjectLena.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreReposiroty _genreReposiroty;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdministratorController(IWebHostEnvironment environment,IBookRepository bookRepository,IGenreReposiroty genreReposiroty)
        {
            _bookRepository = bookRepository;
            _genreReposiroty = genreReposiroty;
            _hostingEnvironment = environment;
        }

        public IActionResult Index(int GenreId = -1)
        {
            // no genre selected -> show all books
            ViewBag.Books = _bookRepository.GetAllBooks();

            // genre selected -> show books in that genre
            if (GenreId != -1)
                ViewBag.Books = _bookRepository.GetBooksByGenre(GenreId);

            // allows the user to select genre name by genre id
            var genres = _genreReposiroty.GetGenres();
            ViewBag.SelectedGenreId = GenreId;

            return View(genres);
        }

        public IActionResult Create(int GenreId = -1)
        {
            // allows the user to select genre name by genre id
            var genres = _genreReposiroty.GetGenres();
            ViewBag.SelectedGenreId = GenreId;

            return View(genres);
        }

        [HttpPost]
        public async Task<ActionResult> AddBookToDb()
        {
            var imageBinaryData = Request.Form.Files[0];

            // generates a unique name for image when saving to images folder,
            // which makes it possible to save images with the same name without conflicts.
            string imageName = Guid.NewGuid().ToString().Replace("-", "") + imageBinaryData.FileName;
            
            // path for the images folder insdie the wwwroot
            string imagesFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");

            // path for the file including image name
            string filePath = Path.Combine(imagesFolderPath, imageName);

            // copies and saves the image to the path defined in filepath
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageBinaryData.CopyToAsync(fileStream);
            }

            BookModel newBook = new();

            // uses all information passed from view to create a new book with it
            int.TryParse(Request.Form["ReleaseYear"].FirstOrDefault(), out int releaseYear);
            int.TryParse(Request.Form["GenreId"]    .FirstOrDefault(), out int genreId);

            newBook.ReleaseYear =  releaseYear;
            newBook.Title       =  Request.Form["Title"].FirstOrDefault();
            newBook.Author      =  Request.Form["Author"].FirstOrDefault();
            newBook.ImageName   =  imageName;
            newBook.Description =  Request.Form["Description"].FirstOrDefault();
            newBook.GenreId     =  genreId;

            _bookRepository.AddBook(newBook);

            return Json(new { Result = "Success" });
        }

        public IActionResult Delete(int id)
        {
            // gets book by id
            ViewBag.Book = _bookRepository.GetBook(id);

            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // deletes book by id 
            _bookRepository.DeleteBook(id);

            return RedirectToAction(nameof(Index));
        }

        public  IActionResult Edit(int id)
        {
            // get books by id
            ViewBag.Book = _bookRepository.GetBook(id);

            // passes id to view
            ViewBag.Book.BookId = id;

            // allows the user to select genre name by genre id
            ViewBag.Genres = _genreReposiroty.GetGenres();
            ViewBag.SelectedGenreId = ViewBag.Book.GenreId;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveEditedBook()
        {
            // similar to addBookToDb, what's different is the use of bookId,
            // which is needed to edit an existing book using the editbook function
            var imageBinaryData     = Request.Form.Files[0];
            string imageName        = Guid.NewGuid().ToString().Replace("-", "") + imageBinaryData.FileName;
            string imagesFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            string filePath         = Path.Combine(imagesFolderPath, imageName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageBinaryData.CopyToAsync(fileStream);
            }

            BookModel editedBook = new();

            int.TryParse(Request.Form["BookId"].FirstOrDefault(), out int bookId);
            int.TryParse(Request.Form["GenreId"]    .FirstOrDefault(), out int genreId);
            int.TryParse(Request.Form["ReleaseYear"].FirstOrDefault(), out int releaseYear);

            editedBook.BookId      =  bookId;
            editedBook.ReleaseYear =  releaseYear;
            editedBook.Title       =  Request.Form["Title"].FirstOrDefault();
            editedBook.Author      =  Request.Form["Author"].FirstOrDefault();
            editedBook.ImageName   =  imageName;
            editedBook.Description =  Request.Form["Description"].FirstOrDefault();
            editedBook.GenreId     =  genreId;

            _bookRepository.EditBook(editedBook.BookId, editedBook);

            return Json(new { Result = "Success" });
        }
    }
}
