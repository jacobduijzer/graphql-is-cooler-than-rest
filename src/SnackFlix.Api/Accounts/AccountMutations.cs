using HotChocolate.Subscriptions;

namespace SnackFlix.Api.Accounts;

[ExtendObjectType("mutations")]
public class AccountMutations(IAccountService accounts, ITopicEventSender sender)
{
    [GraphQLName("createAccount")]
    public async Task<AccountAddedPayload> Add(
        string firstName, 
        string lastName, 
        string email,
        string password, CancellationToken cancellationToken)
    {
        var account = await accounts.Add(firstName, lastName, email, password);
        await sender.SendAsync(nameof(AccountSubscriptions.OnAccountAdded), new AccountSubscriptionPayload(account));
        return new AccountAddedPayload(account);
    }
}