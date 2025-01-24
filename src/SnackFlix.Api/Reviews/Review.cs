namespace SnackFlix.Api.Reviews;

public record Review(int Id, int AccountId, int MovieId, int Rating);