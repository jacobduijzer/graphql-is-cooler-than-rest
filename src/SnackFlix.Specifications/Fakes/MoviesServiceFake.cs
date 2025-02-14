using SnackFlix.Api.Movies;

namespace SnackFlix.Specifications.Fakes;

public class MoviesServiceFake : IMoviesService
{
    public Task<IEnumerable<Movie>> Movies() => Task.FromResult(_movies.AsEnumerable());

    public Task<Movie> Movie(int id) => Task.FromResult(_movies.Single(x => x.Id == id));

    public Task<IEnumerable<Movie>> Movies(string genre) =>
        Task.FromResult(_movies.Where(x => x.Genres.Any(y => y.Equals(genre))));

    public Task<IEnumerable<string>> Genres() =>
        Task.FromResult(_movies.SelectMany(x => x.Genres).Distinct().AsEnumerable());

    private List<Movie> _movies = new()
    {
        new Movie(
            1,
            "The Shawshank Redemption",
            "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion.",
            1997,
            ["Crime", "Drama"]
        ),
        new Movie(
            2,
            "The Godfather",
            "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
            1972,
            ["Crime", "Drama"]
        ),
        new Movie(
            3,
            "The Dark Knight",
            "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
            2008,
            ["Crime", "Drama"]
        ),
        new Movie(
            4,
            "Jurrasic Park",
            "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids after a power failure causes the park's cloned dinosaurs to run loose",
            1993,
            ["Action", "Adventure", "Sci-Fi"]
        )
    };
}