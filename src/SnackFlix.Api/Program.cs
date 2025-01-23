using SnackFlix.Api.Movies;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("queries"))
    .AddType<MovieQueries>();

var app = builder.Build();
app.UseSwaggerWithUi();
app.MapGraphQL();

app.Run();