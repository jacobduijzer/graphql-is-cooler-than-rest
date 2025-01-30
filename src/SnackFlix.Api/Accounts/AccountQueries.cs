namespace SnackFlix.Api.Accounts;

[ExtendObjectType("queries")]
public class AccountQueries(IAccountService account)
{
    public async Task<LoginResult> Login(string email, string password) => 
        await account.Login(email, password);
}