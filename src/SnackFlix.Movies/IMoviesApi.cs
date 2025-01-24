using Refit;

namespace SnackFlix.Movies;

public interface IMoviesApi
{
    [Get("/movies")]
    Task<IEnumerable<Movie>> All();

    [Get("/movies/{id}")]
    Task<Movie> ById(int id);
   
    [Get("/movies/?genre_like={genre}")]
    Task<IEnumerable<Movie>> ByGenre(string genre);
}