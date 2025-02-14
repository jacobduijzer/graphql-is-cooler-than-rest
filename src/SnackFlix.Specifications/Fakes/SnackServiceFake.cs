using SnackFlix.Api;

namespace SnackFlix.Specifications.Fakes;

public class SnackServiceFake : ISnackService
{
    public Task<IEnumerable<string>> GetRecommendations(List<string> genres) =>
       Task.FromResult(new List<string>() { "M&Ms", "Croky Chips" }.AsEnumerable()); 
}