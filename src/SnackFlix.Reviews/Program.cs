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

app.MapGet("/ratings/{movieId}", async (IReviewsApi reviews, int movieId) =>
{
    var allReviews = await reviews.Reviews(movieId);
    return allReviews.Select(x => x.Rating).ToList();
});

app.MapPost("/review/add", async (IReviewsApi reviews, [FromBody] Review review) =>
{
    if(review.Rating is < 0 or > 5)
        return Results.BadRequest("Rating must be between 0 and 5");
    
    await reviews.Add(review);
    return Results.Created($"/review/{review.Id}", review);
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

app.Run();