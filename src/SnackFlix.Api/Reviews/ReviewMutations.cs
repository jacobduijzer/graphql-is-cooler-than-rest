using HotChocolate.Subscriptions;

namespace SnackFlix.Api.Reviews;

[ExtendObjectType("mutations")]
public class ReviewMutations(IReviewService reviews, ITopicEventSender sender)
{
    public async Task<ReviewAddedPayload> Add(int movieId, int accountId, int rating)
    {
        // TODO: extract account id from token
        var newReview = await reviews.Add(new Review(0, accountId, movieId, rating));
        await sender.SendAsync(nameof(ReviewSubscriptions.OnReviewAdded), newReview); 
        return new ReviewAddedPayload(newReview);
    }
}