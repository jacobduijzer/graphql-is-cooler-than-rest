using HotChocolate.Subscriptions;
using Refit;

namespace SnackFlix.Api.Reviews;

[ExtendObjectType("mutations")]
public class ReviewMutations(IReviewService reviews, ITopicEventSender sender, IHttpContextAccessor contextAccessor)
{
    public async Task<ReviewAddedPayload> Add(int movieId, int rating)
    {
        var accountId = contextAccessor.GetAccountId();
        var newReview = await reviews.Add(new Review(0, accountId, movieId, rating));
        await sender.SendAsync(nameof(ReviewSubscriptions.OnReviewAdded), newReview);
        return new ReviewAddedPayload($"Your review, with id '{newReview.Id}' has been added");
    }
    
    public async Task<ReviewDeletedPayload> Delete(int reviewId)
    {
        var result = await reviews.Delete(reviewId);
        if(result.IsSuccessful)
            return new ReviewDeletedPayload(reviewId);
        
        throw new Exception(result.Error.Message);
    }
}