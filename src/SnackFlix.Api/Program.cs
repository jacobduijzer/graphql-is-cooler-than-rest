using SnackFlix.Api;
using SnackFlix.Api.Movies;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddServiceConnections();

builder.Services
    .AddGraphQLServer()
    .AddType<MovieType>()
    .AddQueryType(q => q.Name("queries"))
    .AddType<MovieQueries>()
    .AddFiltering();

var app = builder.Build();
app.UseSwaggerWithUi();
app.MapGraphQL();

app.Run();