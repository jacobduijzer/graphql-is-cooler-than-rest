namespace SnackFlix.Accounts;

public record CreateAccountPayload(
    int Id, 
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime CreatedAt);