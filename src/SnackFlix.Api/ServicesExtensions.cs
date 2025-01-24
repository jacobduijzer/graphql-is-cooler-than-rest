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
        return builder;
    }
}