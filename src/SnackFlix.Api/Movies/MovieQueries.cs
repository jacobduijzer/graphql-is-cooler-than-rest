namespace SnackFlix.Api.Movies;

[ExtendObjectType("queries")]
public class MovieQueries(IMoviesService movies)
{
   public async Task<IQueryable<Movie>> AllMovies() 
   { 
      var allMovies = await movies.Movies();
      return allMovies.AsQueryable();
   }
   
   public async Task<Movie> Movie(int id) => 
      await movies.Movie(id);
   
   public async Task<IEnumerable<Movie>> MoviesByGenre(string genre) => 
      await movies.Movies(genre);
   
   public async Task<IEnumerable<string>> Genres() =>
      await movies.Genres();
}