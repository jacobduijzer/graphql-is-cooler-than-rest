using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SnackFlix.Api;
using SnackFlix.Api.Movies;
using SnackFlix.Api.Reviews;
using SnackFlix.Specifications.Fakes;

namespace SnackFlix.Specifications;

public class CustomWebApplicationFactory :  WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<IMoviesService, MoviesServiceFake>();
            services.AddScoped<ISnackService, SnackServiceFake>();
            services.AddScoped<IReviewService, ReviewServiceFake>();
        });
    }
    
    public ISnackFlixClient CreateSnackFlixClient(string bearerToken = "")
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddSnackFlixClient()
            .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(Server.BaseAddress, "graphql");
                    if(!string.IsNullOrEmpty(bearerToken))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                },
                c =>
                {
                    c.ConfigurePrimaryHttpMessageHandler(() => Server.CreateHandler());
                });

        return serviceCollection
            .BuildServiceProvider()
            .GetRequiredService<ISnackFlixClient>();
    }
}
