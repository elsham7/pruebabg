using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApiComun.Utilities
{
    public class JWT
    {
        public static string GenerarToken(IEnumerable<Claim> claims)
        {
            var secretKey = Comun.ConfigApp.GetSection("SecretKeyJWT").Value;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        public static string GenerarRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public static ClaimsPrincipal ConsultarClaim(string token)
        {
            var secretKey = Comun.ConfigApp.GetSection("SecretKeyJWT").Value;

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //es posible que desee validar la audiencia y el emisor según su caso de uso
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateLifetime = false //aquí estamos diciendo que no nos importa la fecha de vencimiento del token
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
