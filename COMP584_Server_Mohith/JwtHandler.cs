using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorldModel;

namespace COMP584_Server_Mohith
{
    public class JwtHandler(UserManager<WorldModelUser> userManager, IConfiguration configuration)
    {
    public async Task<JwtSecurityToken> GenerateTokenAsync(WorldModelUser user)
        {
            // Implementation for generating JWT token
            return new JwtSecurityToken
            ( 
                    issuer: configuration["JwtSettings:Issuer"],
                    audience: configuration["JwtSettings:Audience"],
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["JwtSettings:ExpiryInMinutes"])),
                    claims : await GetClaimsAsync(user),
                    signingCredentials : GetSigningCredentials()
            );

           
        }
    private SigningCredentials GetSigningCredentials()
        {
            // Implementation for getting signing credentials
            byte[] key = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!);
            var signingKey = new SymmetricSecurityKey(key);
            return new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256);
        }
    private async Task<List<Claim>> GetClaimsAsync(WorldModelUser user)
        {
            // Implementation for getting claims
            List<Claim> claims = [new Claim(ClaimTypes.Name, user.UserName!)];
            //claims.AddRange(await userManager.GetRolesAsync(user)).Select(role => new Claim(ClaimTypes.Role, role));
            foreach(var role in await userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            return claims;
        }

    }
}
