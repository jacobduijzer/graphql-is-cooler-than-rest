using SnackFlix.Api;
using SnackFlix.Api.Movies;
using SnackFlix.Api.Reviews;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddServiceConnections();

builder.Services
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddType<MovieType>()
    .AddType<ReviewType>()
    .AddQueryType(q => q.Name("queries"))
    .AddType<MovieQueries>()
    .AddMutationType(m => m.Name("mutations"))
    .AddType<ReviewMutations>()
    .AddSubscriptionType(s => s.Name("subscriptions"))
    .AddType<ReviewSubscriptions>()
    .AddFiltering();

var app = builder.Build();
app.UseSwaggerWithUi();
app.UseWebSockets();
app.MapGraphQL();

app.Run();