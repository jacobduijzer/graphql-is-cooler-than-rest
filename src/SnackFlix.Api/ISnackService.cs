using Refit;

namespace SnackFlix.Api;

public interface ISnackService
{
    [Post("/recommendations")]
    Task<IEnumerable<string>> GetRecommendations(List<string> genres);
}