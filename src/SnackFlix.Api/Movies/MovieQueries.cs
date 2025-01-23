namespace SnackFlix.Api.Movies;

[ExtendObjectType("queries")]
public class MovieQueries
{
   [GraphQLName("movies")]
   public Task<IQueryable<Movie>> AllMovies() => default;
}