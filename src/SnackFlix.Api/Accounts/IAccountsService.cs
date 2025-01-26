using Refit;

namespace SnackFlix.Api.Accounts;

public interface IAccountsService
{
    [Get("/login")]
    Task<LoginResult> Login(string email, string password);
}