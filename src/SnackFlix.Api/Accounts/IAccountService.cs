using Refit;

namespace SnackFlix.Api.Accounts;

public interface IAccountService
{
    [Get("/login")]
    Task<LoginResult> Login(string email, string password);
}