namespace SnackFlix.Api.Accounts;

public record AccountSubscriptionPayload(Account Account)
{
   public string Message => $"{Account.FirstName} has created a new account";
}