using SnackFlix.Api;
using SnackFlix.Api.Movies;
using SnackFlix.Api.Reviews;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddServiceConnections();

builder.Services
    .AddGraphQLServer()
    .AddType<MovieType>()
    .AddQueryType(q => q.Name("queries"))
    .AddType<MovieQueries>()
    .AddMutationType(m => m.Name("mutations"))
    .AddType<ReviewMutations>()
    .AddFiltering();

var app = builder.Build();
app.UseSwaggerWithUi();
app.MapGraphQL();

app.Run();