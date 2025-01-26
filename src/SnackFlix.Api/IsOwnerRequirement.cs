using System.Security.Claims;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using SnackFlix.Api.Reviews;

namespace SnackFlix.Api;

public class IsOwnerRequirement() : IAuthorizationRequirement { }

public class IsOwnerHandler : AuthorizationHandler<IsOwnerRequirement, IResolverContext>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        IsOwnerRequirement requirement,
        IResolverContext resource)
    {
        var accountId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        if (context.Resource is Review review && review.AccountId == accountId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}