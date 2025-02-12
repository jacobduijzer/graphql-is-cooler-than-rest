namespace SnackFlix.Api.Reviews;

public class ReviewsDataLoader(IReviewService reviews, IBatchScheduler batchScheduler, DataLoaderOptions options)
    : GroupedDataLoader<int, Review>(batchScheduler, options)
{
    protected override async Task<ILookup<int, Review>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var allReviews = await reviews.Reviews(keys.ToList());
        return allReviews.ToLookup(p => p.MovieId);
    }
}