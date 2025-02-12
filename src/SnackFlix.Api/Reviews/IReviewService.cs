using Refit;

namespace SnackFlix.Api.Reviews;

public interface IReviewService
{
    [Get("/reviews/{movieId}")]
    Task<IEnumerable<Review>> Ratings(int movieId);
    
    [Get("/review/{reviewId}")]
    Task<IApiResponse<Review>> Review(int reviewId);
    
    [Post("/review/add")]
    Task<Review> Add(Review review);
    
    [Post("/reviews")]
    Task<IEnumerable<Review>> Reviews([Body]List<int> movieIds);
    
    [Delete("/review/{reviewId}")]
    Task<IApiResponse> Delete(int reviewId);
}