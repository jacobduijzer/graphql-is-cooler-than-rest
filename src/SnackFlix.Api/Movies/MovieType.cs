namespace SnackFlix.Api.Movies;

public class MovieType : ObjectType<Movie>
{
    protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
    {
        descriptor
            .Field("snacks")
            .Type<ListType<StringType>>()
            .Resolve(async (context) =>
            {
                var snackService = context.Service<ISnackService>();
                var movie = context.Parent<Movie>();
                return await snackService.GetRecommendations(movie.Genres.ToList());
            });
        
        descriptor
            .Field("ratings")
            .Type<ListType<IntType>>()
            .Resolve(async (context) =>
            {
                var reviewService = context.Service<IReviewService>();
                var movie = context.Parent<Movie>();
                return await reviewService.Ratings(movie.Id);
            });
    }
}