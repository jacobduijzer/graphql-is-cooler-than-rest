using Refit;

namespace SnackFlix.Api.Movies;

public interface IMoviesApi
{
    [Get("/all")]
    Task<IEnumerable<Movie>> Movies();
    
    [Get("/movie/{id}")]
    Task<Movie> Movie(int id);
    
    [Get("/movies/genre/{genre}")]
    Task<IEnumerable<Movie>> Movies(string genre);

    [Get("/genres")]
    Task<IEnumerable<string>> Genres();
}