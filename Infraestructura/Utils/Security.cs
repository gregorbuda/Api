using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Utils
{
    public class Security
    {
        public static string GenerateToken()
        {
            var issuer = "https://localhost:7005/";
            var audience = "https://localhost:7005/";
            var expiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes("GmCuH67mzPWYbb4W4uDLPprHjzLh01jTpJWmZoLy620jfTT9nWP5zg="));
            var credentials = new SigningCredentials
            (securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(60),
            claims: new List<Claim>(),
            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
