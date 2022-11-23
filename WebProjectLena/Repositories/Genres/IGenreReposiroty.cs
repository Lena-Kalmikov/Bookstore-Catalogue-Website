using WebProjectLena.Models;

namespace WebProjectLena.Repositories.Genres
{
    public interface IGenreReposiroty
    {
        IEnumerable<GenreModel> GetGenres();
    }
}
