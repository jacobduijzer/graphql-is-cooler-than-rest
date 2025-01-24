using Microsoft.AspNetCore.Mvc;
using SnackFlix.Snacks;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddScoped<SnackRecommendationService>();

var app = builder.Build();
app.UseSwaggerWithUi();
app.MapPost("/recommendations", (SnackRecommendationService recommendations, [FromBody] List<string> genres) => 
    recommendations.Get(genres));
app.Run();