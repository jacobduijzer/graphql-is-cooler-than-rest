namespace SnackFlix.Api.Movies;

[ExtendObjectType("queries")]
public class MovieQueries(IMoviesService movies)
{
   [GraphQLDescription("Get a list of all available movies")]
   public async Task<IQueryable<Movie>> AllMovies() 
   { 
      var allMovies = await movies.Movies();
      return allMovies.AsQueryable();
   }
   
   [GraphQLDescription("Get the details of a movie.")]
   public async Task<Movie> Movie(int id) => 
      await movies.Movie(id);
   
   [GraphQLDescription("Get all movies with a specific genre.")]
   public async Task<IEnumerable<Movie>> MoviesByGenre(string genre) => 
      await movies.Movies(genre);
   
   [GraphQLDescription("Get all unique genres that are available.")]
   public async Task<IEnumerable<string>> Genres() =>
      await movies.Genres();
}