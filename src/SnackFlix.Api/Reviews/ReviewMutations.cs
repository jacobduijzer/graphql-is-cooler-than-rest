namespace SnackFlix.Api.Reviews;

[ExtendObjectType("mutations")]

public class ReviewMutations(IReviewService reviews)
{
    public async Task<ReviewAddedPayload> Add(Review review)
    {
        var newReview = await reviews.Add(review);
        return new ReviewAddedPayload(newReview);
    }
}