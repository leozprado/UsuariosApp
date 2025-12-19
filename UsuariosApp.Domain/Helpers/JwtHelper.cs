using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Helpers
{
    /// <summary>
    /// Classe para gerar o TOKEN JWT
    /// </summary>
    public class JwtHelper
    {
        /// <summary>
        /// Chave utilizada para criptografar / assinar o token
        /// </summary>
        private static string _secretKey = "21D34BA9-8080-4339-A0C0-8A29B8D69F3D";

        /// <summary>
        /// Métood para gerar o TOKEN JWT
        /// </summary>
        public static string GenerateToken(string email, string perfil)
        {
            // Claims (informações gravadas dentro do token)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, perfil)
            };

            // Chave de segurança
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_secretKey)
            );

            // Credenciais de assinatura
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            // Criação do token
            var token = new JwtSecurityToken(
                issuer: "UsuariosApp",
                audience: "UsuariosApp",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2), //expiração em 2 horas
                signingCredentials: credentials
            );

            // Retorno do token como string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
