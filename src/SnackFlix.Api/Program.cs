using SnackFlix.Api;
using SnackFlix.Api.Accounts;
using SnackFlix.Api.Movies;
using SnackFlix.Api.Reviews;
using IAuthorizationHandler = Microsoft.AspNetCore.Authorization.IAuthorizationHandler;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.ConfigureAuthentication();
builder.ConfigureAuthorization();
builder.AddServiceConnections();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationHandler, IsOwnerOrAdminRequirementHandler>();
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddInMemorySubscriptions()
    .AddDataLoader<ReviewsDataLoader>()
    .AddQueryType(q => q.Name("queries"))
    .AddType<AccountQueries>()
    .AddTypeExtension<AccountQueriesType>()
    .AddType<MovieQueries>()
    .AddTypeExtension<MovieQueriesType>()
    .AddMutationType(m => m.Name("mutations"))
    .AddType<AccountMutations>()
    .AddType<ReviewMutations>()
    .AddTypeExtension<ReviewMutationsType>()
    .AddSubscriptionType(s => s.Name("subscriptions"))
    .AddType<AccountSubscriptions>()
    .AddType<ReviewSubscriptions>()
    .AddFiltering();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(corsBuilder =>
            corsBuilder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

var app = builder.Build();
app
    .UseAuthentication()
    .UseAuthorization();
app.UseWebSockets();
app.MapGraphQL();
app.UseCors();
app.Run();