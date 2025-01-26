using Refit;

namespace SnackFlix.Accounts;

public interface IAccountsApi
{
    [Get("/accounts/?email={email}&password={password}")]
    Task<IEnumerable<Account>> Login(string email, string password); 
}