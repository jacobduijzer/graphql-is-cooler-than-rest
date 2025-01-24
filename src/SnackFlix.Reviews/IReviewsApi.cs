using Refit;

namespace SnackFlix.Reviews;

public interface IReviewsApi
{
    [Get("/reviews/{reviewId}")]
    Task<Review> Review(int reviewId);
    
    [Get("/reviews/?movieId={movieId}")]
    Task<IEnumerable<Review>> Reviews(int movieId);
    
    [Post("/reviews")]
    Task<Review> Add(Review review);
}