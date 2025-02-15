using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;
using SnackFlix.Api;
using StrawberryShake;
using Xunit;

namespace SnackFlix.Specifications.Accounts;

[Binding]
public class Login(CustomWebApplicationFactory factory, ScenarioContext scenarioContext) :
    IClassFixture<WebApplicationFactory<Program>>
{
    private const string LoginResult = "login-result";

    [Given(@"Alex wants to login")]
    public void GivenAlexWantsToLogin()
    {
        // DO NOTHING
    }

    [When(@"he uses the username ""(.*)"" and the password ""(.*)""")]
    public async Task WhenHeUsesTheUsernameAndThePassword(string username, string password)
    {
        var loginResult = await factory.CreateSnackFlixClient().Login.ExecuteAsync(username, password);
        scenarioContext.Add(LoginResult, loginResult);
    }

    [Then(@"he gets a token and is succesfully logged in")]
    public void ThenHeGetsATokenAndIsSuccesfullyLoggedIn()
    {
        var loginResult = scenarioContext.Get<IOperationResult<ILoginResult>>(LoginResult);
        Assert.Empty(loginResult.Errors);
        Assert.NotNull(loginResult.Data);
        Assert.NotEmpty(loginResult.Data.Login.BearerToken);
    }
}