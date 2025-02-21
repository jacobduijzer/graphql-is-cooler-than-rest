namespace SnackFlix.Api.Accounts;

[ExtendObjectType("queries")]
public class AccountQueries(IAccountService account)
{
    [GraphQLDescription("Login with an email and a password to retrieve a bearer token.")]
    public async Task<LoginResult> Login(string email, string password) => 
        await account.Login(email, password);
}