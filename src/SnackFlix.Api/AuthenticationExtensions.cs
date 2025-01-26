using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace SnackFlix.Api;

public static class AuthenticationExtensions
{
    public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        var privateKey = builder.Configuration["Identity:PrivateKey"] ??
                         throw new InvalidOperationException("Missing Identity:PrivateKey configuration");

        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return builder;
    }

    public static WebApplicationBuilder ConfigureAuthorization(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(configure =>
        {
            configure.AddPolicy("IsAdmin", policy =>
                policy.RequireAssertion(context =>
                    context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Admin")));

            // TODO: Make it work
            configure.AddPolicy("IsOwner", policy =>
                policy.Requirements.Add(new IsOwnerRequirement()));
        });

        return builder;
    }

    public static int GetAccountId(this IHttpContextAccessor httpContextAccessor) =>
        int.Parse(httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}