using Microsoft.AspNetCore.Mvc;
using Refit;
using SnackFlix.Reviews;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services
    .AddRefitClient<IReviewsApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["CONTENT_ENDPOINT"]!));
    
var app = builder.Build();
app.UseSwaggerWithUi();

app.MapGet("/review/{reviewId}", async (IReviewsApi reviews, int reviewId) =>
{
    var review = await reviews.Review(reviewId);
    return review;
});

app.MapGet("/reviews/{movieId}", async (IReviewsApi reviews, int movieId) =>
    await reviews.Reviews(movieId));

app.MapPost("/review/add", async (IReviewsApi reviews, [FromBody] Review review) =>
{
    if(review.Rating is < 0 or > 5)
        return Results.BadRequest("Rating must be between 0 and 5");
    
    var addedReview = await reviews.Add(review);
    return Results.Created($"/review/{addedReview.Id}", addedReview);
});

app.MapPost("/reviews", async (IReviewsApi reviews, [FromBody] List<int> movieIds) =>
{
    List<Review> allReviews = new();
    foreach (var movieId in movieIds)
    {
        var review = await reviews.Reviews(movieId);
        allReviews.AddRange(review);
    }
    return allReviews;
});

app.MapDelete("/review/{reviewId}", async (IReviewsApi reviews, int reviewId) =>
{
    var result = await reviews.Delete(reviewId);
    return result.IsSuccessStatusCode ? Results.NoContent() : Results.NotFound();
});

app.Run();