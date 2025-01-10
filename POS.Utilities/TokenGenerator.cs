using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace POS.Utilities
{
    public class TokenGenerator
    {
        private readonly IConfiguration configuration;

        public TokenGenerator(IConfiguration config)
        {
            configuration = config;
        }


        public async Task<string> IssueToken(Guid id, string email, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("88762cdc83a54fd15893d7fbe00d9dae6cbd2d4c51a1fb66cd831fe50bcd362ab197b560beed42fca4d1646fdfb3da1636f86f6eb4c1d62a836a5dde99db9140cde1a749bbe27ccc26830d3b9e3c8344869561458fa0082407479a30a1a89bc2f59a476bb7ac5855fcd30a7c9a29193394ac91855e74dab3d07e58894f60e6866dd0aaa7718f2eb12a86d0d4b0f82650a5a2b8117e2c4d445127c95ae7a20a6c84d0c8436f6bdd129123eeec2b1c4aa497af7915173a9e33500daf405320f6b5e6001b2f2a608c46eefc9cee22d211c432dc1a3ee5be391298a4da32cd8102c0864c92f5854cdd5d4d59c8ce55169c951d5d57b16e358b5484e3d4e5284321b6"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
            };

            var token = new JwtSecurityToken(
                issuer: "Authenticator",
                audience: "Resource",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
               signingCredentials: credentials);


           return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
