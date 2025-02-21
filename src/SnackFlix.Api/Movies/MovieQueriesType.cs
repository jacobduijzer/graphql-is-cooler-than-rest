namespace SnackFlix.Api.Movies;

public class MovieQueriesType : ObjectTypeExtension<MovieQueries>
{
    protected override void Configure(IObjectTypeDescriptor<MovieQueries> descriptor)
    {
        descriptor
            .Field(f => f.AllMovies())
            .Name("movies")
            .Description("Returns all movies from the database.")
            .Type<ListType<MovieType>>()
            .UsePaging()
            .UseFiltering();
    }
}