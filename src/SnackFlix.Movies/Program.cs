using Refit;
using SnackFlix.Movies;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services
    .AddRefitClient<IMoviesApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["CONTENT_ENDPOINT"]!));

var app = builder.Build();
app.UseSwaggerWithUi();
app.MapGet("/all", async (IMoviesApi movies) => await movies.All());
app.MapGet("/movie/{id}", async (IMoviesApi movies, int id) => await movies.ById(id));
app.MapGet("/movies/genre/{genre}", async (IMoviesApi movies, string genre) => await movies.ByGenre(genre));
app.MapGet("/genres", async (IMoviesApi movies) => 
{
    var allMovies = await movies.All();
    return allMovies
        .SelectMany(m => m.Genre)
        .Distinct();
});
app.Run();