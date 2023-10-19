using Fiap.Api.Donation.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Api.Donation.Service
{
    public class AuthenticationService
    {

        public static string GetToken(UsuarioModel usuarioModel)
        {
            byte[] secret = Encoding.ASCII.GetBytes("68f1549c-3163-4ae5-a7b5-7b406c23c435");

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim( ClaimTypes.Name, usuarioModel.NomeUsuario ),
                    new Claim( ClaimTypes.Role, usuarioModel.Regra),
                    new Claim( ClaimTypes.Email, usuarioModel.EmailUsuario),
                    new Claim("UsuarioId", usuarioModel.UsuarioId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(secret),
                                SecurityAlgorithms.HmacSha256Signature),
            };

            SecurityToken securityToken = handler.CreateToken(securityTokenDescriptor);

            return handler.WriteToken(securityToken);
        }


    }
}