using Refit;
using SnackFlix.Api.Reviews;

namespace SnackFlix.Api;

public interface IReviewService
{
    [Get("/ratings/{movieId}")]
    Task<IEnumerable<int>> Ratings(int movieId);
    
    [Post("/review/add")]
    Task<Review> Add(Review review);
}