using Aspire.Hosting;
using Aspire.Hosting.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SnackFlix.Testing;

public class TestingAspireAppHost() : DistributedApplicationFactory(typeof(Projects.SnackFlix_AppHost))
{
    protected override void OnBuilderCreating(
        DistributedApplicationOptions applicationOptions,
        HostApplicationBuilderSettings hostOptions)
    {
        applicationOptions.DisableDashboard = true;
    }

    protected override void OnBuilderCreated(DistributedApplicationBuilder applicationBuilder)
    {
    }

    protected override void OnBuilding(DistributedApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Services
            .AddSnackFlixClient();
        // .ConfigureHttpClient(client =>
        //     {
        //         client.BaseAddress = new Uri(Server.BaseAddress, "graphql");
        //         // if(!string.IsNullOrEmpty(bearerToken))
        //             // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        //     },
        //     c =>
        //     {
        //         c.ConfigurePrimaryHttpMessageHandler(() => Server.CreateHandler());
        //     });            
        // applicationBuilder.Services.AddScoped<IsNullOrEmptya
    }
}