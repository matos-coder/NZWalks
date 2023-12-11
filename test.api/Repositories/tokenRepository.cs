using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace test.api.Repositories
{
    public class tokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public tokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string createJwtToken(IdentityUser user, List<string> roles)
        {
           
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(50),
                signingCredentials:credential);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
