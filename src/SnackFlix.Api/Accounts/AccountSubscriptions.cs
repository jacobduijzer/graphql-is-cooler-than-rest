namespace SnackFlix.Api.Accounts;

[ExtendObjectType("subscriptions")]
public class AccountSubscriptions
{
    [Subscribe]
    [Topic(nameof(OnAccountAdded))]
    [GraphQLDescription("subscribe on the events for new account creations.")]
    public AccountSubscriptionPayload OnAccountAdded([EventMessage] AccountSubscriptionPayload payload) =>
        payload;
}