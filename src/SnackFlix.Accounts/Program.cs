using Refit;
using SnackFlix.Accounts;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddScoped<IdentityService>();
builder.Services
    .AddRefitClient<IAccountsApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["CONTENT_ENDPOINT"]!));

var app = builder.Build();
app.UseSwaggerWithUi();

app.MapGet("/login", async (IdentityService identity, string email, string password) =>
{
    var login = await identity.Login(email, password);
    return !string.IsNullOrEmpty(login.BearerToken) ? Results.Ok(login) : Results.Unauthorized();
});

app.MapPost("/create", async (IAccountsApi accounts, string firstName, string lastName, string email, string password) =>
{
    var account = await accounts.Create(new CreateAccountPayload(0, firstName, lastName, email, password, DateTime.Now));
    return account;
});

app.Run();