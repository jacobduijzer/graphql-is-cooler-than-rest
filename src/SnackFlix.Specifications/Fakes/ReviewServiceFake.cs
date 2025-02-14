using Refit;
using SnackFlix.Api.Reviews;

namespace SnackFlix.Specifications.Fakes;

public class ReviewServiceFake : IReviewService
{
    public Task<IEnumerable<Review>> Ratings(int movieId) => 
        Task.FromResult<IEnumerable<Review>>(new List<Review>
        {
            new Review(1, 1, movieId, 2),
            new Review(2, 2, movieId, 4)
        });

    public Task<IApiResponse<Review>> Review(int reviewId)
    {
        throw new NotImplementedException();
    }

    public Task<Review> Add(Review review)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> Reviews(List<int> movieIds)
    {
        throw new NotImplementedException();
    }

    public Task<IApiResponse> Delete(int reviewId)
    {
        throw new NotImplementedException();
    }
}