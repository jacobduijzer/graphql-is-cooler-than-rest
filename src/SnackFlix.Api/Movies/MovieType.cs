using SnackFlix.Api.Reviews;

namespace SnackFlix.Api.Movies;

public class MovieType : ObjectType<Movie>
{
    protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
    {
        descriptor
            .Field(f => f.Year)
            .UseFiltering();

        descriptor
            .Field(f => f.Title)
            .UseFiltering();

        descriptor
            .Field(f => f.Genres)
            .UseFiltering();
        
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
            .Type<ListType<ReviewType>>()
            .Resolve(async (context) =>
            {
                var reviewService = context.Service<IReviewService>();
                var movie = context.Parent<Movie>();
                return await reviewService.Ratings(movie.Id);
            });

        descriptor
            .Field("optimizedRatings")
            .Type<ListType<ReviewType>>()
            .Resolve(async (context) =>
            {
                var movie = context.Parent<Movie>();
                var dataLoader = context.Services.GetRequiredService<ReviewsDataLoader>();
                return await dataLoader.LoadAsync(movie.Id);
            });
    }
}