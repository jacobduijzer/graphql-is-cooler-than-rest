namespace SnackFlix.Api.Reviews;

[ExtendObjectType("subscriptions")]
public class ReviewSubscriptions
{
    [Subscribe]
    [Topic(nameof(OnReviewAdded))]
    public Review? OnReviewAdded([EventMessage] Review? review) =>
        review;
    
    [Subscribe]
    [Topic(nameof(OnReviewAdded))]
    public Review? OnReviewAddedForMovie(int movieId, [EventMessage] Review? review) =>
        review.MovieId == movieId ? review : null;
}