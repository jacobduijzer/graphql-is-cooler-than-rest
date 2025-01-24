namespace SnackFlix.Api.Movies;

public class MovieType : ObjectType<Movie>
{
    protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
    {
        base.Configure(descriptor);
    }
}