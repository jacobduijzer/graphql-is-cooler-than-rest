using Refit;
using SnackFlix.Api.Movies;

namespace SnackFlix.Api;

public static class ServicesExtensions
{
    public static WebApplicationBuilder AddServiceConnections(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddRefitClient<IMoviesApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http+https://movies"));
        
        builder.Services
            .AddRefitClient<ISnackService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http+https://snacks"));
        
        builder.Services
            .AddRefitClient<IReviewService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http+https://reviews"));
        
        return builder;
    }
}