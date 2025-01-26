using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SnackFlix.Accounts;

public class IdentityService(IAccountsApi accounts, IConfiguration configuration)
{
    public async Task<LoginResult> Login(string email, string password)
    {
        var account = await accounts.Login(email, password);
        if (account == null || !account.Any()) throw new UnauthorizedAccessException();

        return new LoginResult(CreateToken(account.First()));
    }

    private string CreateToken(Account account)
    {
        JwtSecurityTokenHandler tokenHandler = new();

        var privateKey = configuration["Identity:PrivateKey"] ??
                         throw new InvalidOperationException("Missing Identity:PrivateKey in configuration");
        
        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = GenerateClaims(account)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private ClaimsIdentity GenerateClaims(Account account)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new Claim(ClaimTypes.GivenName, account.FirstName),
            new Claim(ClaimTypes.Surname, account.LastName),
            new Claim(ClaimTypes.Email, account.Email),
        };
        
        if(account.Email.StartsWith("admin"))
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

        return new ClaimsIdentity(claims);
    } 
}