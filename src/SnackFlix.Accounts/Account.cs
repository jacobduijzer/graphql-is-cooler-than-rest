namespace SnackFlix.Accounts;

public record Account(
    int Id, 
    string FirstName,
    string LastName,
    string Email,
    DateTime CreatedAt);