namespace SnackFlix.Api.Accounts;

[ExtendObjectType("subscriptions")]
public class AccountSubscriptions
{
    [Subscribe]
    [Topic(nameof(OnAccountAdded))]
    public AccountSubscriptionPayload OnAccountAdded([EventMessage] AccountSubscriptionPayload payload) =>
        payload;
}