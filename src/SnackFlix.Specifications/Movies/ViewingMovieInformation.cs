using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;
using SnackFlix.Api;
using StrawberryShake;
using Xunit;

namespace SnackFlix.Specifications.Movies;

[Binding]
public class ViewingMovieInformation(CustomWebApplicationFactory factory, ScenarioContext scenarioContext) :
    IClassFixture<IClassFixture<WebApplicationFactory<Program>>>
{
    private const string MoviesResult = "movies-result";

    [Given(@"Alex wants to watch a movie")]
    public void GivenAlexWantsToWatchAMovie()
    {
        // DO NOTHING
    }

    [Given(@"he doesn't know which movie he wants to watch")]
    public void GivenHeDoesntKnowWhichMovieHeWantsToWatch()
    {
        // DO NOTHING
    }

    [Given(@"Alex has selected a movie he thinks he wants to watch")]
    public void GivenAlexHasSelectedAMovieHeThinksHeWantsToWatch()
    {
        // DO NOTHING
    }
    
    [Given(@"Alex has selected the movie ""(.*)""")]
    public void GivenAlexHasSelectedTheMovie(string movieTitle)
    {
        // DO NOTHING
    }

    [When(@"he searches for a movie to watch")]
    public async Task WhenHeSearchesForAMovieToWatch()
    {
        var moviesResult = await factory.CreateSnackFlixClient().AllMovies.ExecuteAsync();
        scenarioContext.Add(MoviesResult, moviesResult);
    }

    [When(@"he goes to the detail page")]
    public async Task WhenHeGoesToTheDetailPage()
    {
        var movieDetailResult = await factory.CreateSnackFlixClient().MovieDetailsPage.ExecuteAsync();
        scenarioContext.Add(MoviesResult, movieDetailResult);
    }
    
    [When(@"he requests the movie details with snack recommendations and ratings")]
    public async Task WhenHeRequestsTheMovieDetailsWithSnackRecommendationsAndRatings()
    {
        var movieDetailResult = await factory.CreateSnackFlixClient().MovieDetailsPageWithSnacksAndRatings.ExecuteAsync();
        scenarioContext.Add(MoviesResult, movieDetailResult);
    }

    [Then(@"he sees a list with (.*) the movies available, with the genres")]
    public void ThenHeSeesAListWithTheMoviesAvailableWithTheGenres(int numberOfMovies)
    {
        var moviesResult = scenarioContext.Get<IOperationResult<IAllMoviesResult>>(MoviesResult);
        Assert.Empty(moviesResult.Errors);
        Assert.NotNull(moviesResult.Data);
        Assert.NotEmpty(moviesResult.Data.AllMovies);
        Assert.Equal(numberOfMovies, moviesResult.Data.AllMovies.Count);
    }

    [Then(@"he sees the movie details")]
    public void ThenHeSeesTheMovieDetails()
    {
        var movieDetailResult = scenarioContext.Get<IOperationResult<IMovieDetailsPageResult>>(MoviesResult);
        Assert.NotNull(movieDetailResult.Errors);
        Assert.NotNull(movieDetailResult.Data);
        Assert.NotNull(movieDetailResult.Data.Movie);
        Assert.Equal("The Shawshank Redemption", movieDetailResult.Data.Movie.Title);
    }

    [Then(@"the genres which can be used to search other movies")]
    public void ThenTheGenresWhichCanBeUsedToSearchOtherMovies()
    {
        var movieDetailResult = scenarioContext.Get<IOperationResult<IMovieDetailsPageResult>>(MoviesResult);
        Assert.NotNull(movieDetailResult.Data.Genres);
    }


    [Then(@"the full list of other movies available")]
    public void ThenTheFullListOfOtherMoviesAvailable()
    {
        var movieDetailResult = scenarioContext.Get<IOperationResult<IMovieDetailsPageResult>>(MoviesResult);
        Assert.NotNull(movieDetailResult.Data.AllMovies);
    }

    [Then(@"he sees the following movie details")]
    public void ThenHeSeesTheFollowingMovieDetails(Table table)
    {
        var movieDetailResult = scenarioContext.Get<IOperationResult<IMovieDetailsPageWithSnacksAndRatingsResult>>(MoviesResult);
        Assert.Empty(movieDetailResult.Errors);
        // TODO 
    }

    [Then(@"he gets the following snack recommendations: ""(.*)""")]
    public void ThenHeGetsTheFollowingSnackRecommendations(string recomendationString)
    {
        var recommendations = recomendationString.Split(",", StringSplitOptions.TrimEntries);
        var movieDetailResult = scenarioContext.Get<IOperationResult<IMovieDetailsPageWithSnacksAndRatingsResult>>(MoviesResult);   
        Assert.All(recommendations, genre => Assert.Contains(genre, movieDetailResult.Data.Movie.Snacks));
    }
}