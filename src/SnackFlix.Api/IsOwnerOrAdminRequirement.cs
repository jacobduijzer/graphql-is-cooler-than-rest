using System.Security.Claims;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using SnackFlix.Api.Reviews;

namespace SnackFlix.Api;

public class IsOwnerOrAdminRequirement : IAuthorizationRequirement { }

public class IsOwnerOrAdminRequirementHandler : 
    AuthorizationHandler<IsOwnerOrAdminRequirement, IResolverContext> {
    
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context, 
        IsOwnerOrAdminRequirement requirement,
        IResolverContext resource)
    {
        if (!context.User.Identity.IsAuthenticated)
            return;
        
        // Check if user is admin
        if (context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Admin"))
        {
            context.Succeed(requirement);
            return;
        }
        
        // Check if user is owner
        var accountId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var responseName = resource.Selection.ResponseName;

        if (responseName.Equals("deleteReview"))
        {
            if (resource.Selection.Arguments.TryGetValue("reviewId", out var reviewIdArgument))
            {
                if (reviewIdArgument.Value is int reviewId)
                {
                    var reviewService = resource.Services.GetRequiredService<IReviewService>();
                    var review = await reviewService.Review(reviewId);
                    if (review.IsSuccessful && review.Content.AccountId == accountId)
                    {
                        // User is the owner, can delete review
                        context.Succeed(requirement);
                    }
                }
            }
        }
    }
}