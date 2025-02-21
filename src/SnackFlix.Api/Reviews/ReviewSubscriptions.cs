namespace SnackFlix.Api.Reviews;

[ExtendObjectType("subscriptions")]
public class ReviewSubscriptions
{
    [Subscribe]
    [Topic(nameof(OnReviewAdded))]
    [GraphQLDescription("Subscribe on events for new reviews.")]
    public Review? OnReviewAdded([EventMessage] Review? review) =>
        review;
    
    [Subscribe]
    [Topic(nameof(OnReviewAdded))]
    [GraphQLDescription("Subscribe on events for new reviews on a specific movie.")]
    public Review? OnReviewAddedForMovie(int movieId, [EventMessage] Review? review) =>
        review.MovieId == movieId ? review : null;
}