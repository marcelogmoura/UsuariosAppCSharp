using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Infra.Security.Settings;

namespace UsuariosApp.Infra.Security.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Subject = new ClaimsIdentity(new Claim[]
                    { new Claim(ClaimTypes.Name, usuario.Email) }),
              
                Expires = GenerateExpirationDate(),
               
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public DateTime GenerateExpirationDate()
        {
            return DateTime.UtcNow.AddHours
                (JwtTokenSettings.ExpirationInHours);
        }
    }
}
