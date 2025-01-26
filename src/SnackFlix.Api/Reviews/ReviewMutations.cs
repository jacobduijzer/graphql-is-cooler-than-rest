using HotChocolate.Authorization;
using HotChocolate.Subscriptions;

namespace SnackFlix.Api.Reviews;

public class ReviewMutations(IReviewService reviews, ITopicEventSender sender, IHttpContextAccessor contextAccessor)
{
    public async Task<ReviewAddedPayload> Add(int movieId, int rating)
    {
        var accountId = contextAccessor.GetAccountId();
        var newReview = await reviews.Add(new Review(0, accountId, movieId, rating));
        await sender.SendAsync(nameof(ReviewSubscriptions.OnReviewAdded), newReview); 
        return new ReviewAddedPayload(newReview);
    }

    [Authorize(Policy = "IsOwner")]
    public async Task<ReviewDeletedPayload> Delete(int reviewId)
    {
        await reviews.Delete(reviewId);
        return new ReviewDeletedPayload(reviewId);
    }
}