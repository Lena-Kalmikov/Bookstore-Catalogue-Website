using WebProjectLena.Data;
using WebProjectLena.Models;

namespace WebProjectLena.Repositories.Genres
{
    public class GenreReposiroty : IGenreReposiroty
    {
        private readonly BooksCatalogueContext _context;
        public GenreReposiroty(BooksCatalogueContext context)
        {
            _context = context;
        }
        public IEnumerable<GenreModel> GetGenres()
        {
            return _context.Genres!;
        }
    }
}
