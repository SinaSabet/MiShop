using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Service
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(int userid, string username, string email)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,userid.ToString()),
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role,"normal"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("salamsalam^&*salam$#!afasfasfdsgsdgdsg$%^3sad"));
            var sign = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "IdentityService",
                Issuer = "IdentityService",
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(100),
                SigningCredentials = sign
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var Token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(Token);

        }
    }
}
