namespace SnackFlix.Api.Reviews;

public record ReviewDeletedPayload(int ReviewId)
{
    public string Message => $"Review {ReviewId} has been deleted.";
}