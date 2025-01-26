namespace SnackFlix.Api.Accounts;

[ExtendObjectType("queries")]
public class AccountsQueries(IAccountsService accounts)
{
    public async Task<LoginResult> Login(string email, string password) => 
        await accounts.Login(email, password);
}