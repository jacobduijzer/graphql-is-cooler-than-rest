using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SnackFlix.Razor.Pages;

public class IndexModel(ISnackFlixClient snackFlixClient, ILogger<IndexModel> logger) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;

    public async Task OnGetAsync()
    {
        var data = await snackFlixClient.GetMovieDetailPage.ExecuteAsync();
        Movie = data.Data.Movie;
        Movies = data.Data.AllMovies;
        Genres = data.Data.Genres;
    }

    public IReadOnlyList<string> Genres { get; set; }
    public IGetMovieDetailPage_Movie Movie { get; set; }
    public IReadOnlyList<IGetMovieDetailPage_AllMovies> Movies { get; set; }
}