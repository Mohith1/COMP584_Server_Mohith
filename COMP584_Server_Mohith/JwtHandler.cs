using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace COMP584_Server_Mohith
{
    public class JwtHandler
    {
    public async Task<JwtSecurityToken> GenerateTokenAsync()
        {
            // Implementation for generating JWT token
            return new JwtSecurityToken
            ( 
                    issuer: "YourIssuer",
                    audience: "YourAudience",
                    expires: DateTime.Now.AddHours(1),
                    claims : await GetClaimsAsync(),
                    signingCredentials : GetSigningCredentials()
            );

           
        }
    private SigningCredentials GetSigningCredentials()
        {
            // Implementation for getting signing credentials
            byte[] key = Convert.FromBase64String("YourBase64EncodedSecretKey");
            var signingKey = new SymmetricSecurityKey(key);
            return new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256);
        }
    private async Task<List<Claim>> GetClaimsAsync()
        {
            // Implementation for getting claims
            List<Claim> claims = [new Claim(ClaimTypes.Name, "empty")];
            return await Task.FromResult(new List<Claim>());
        }

    }
}
