using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application.Services.Token
{
    public class TokenController
    {
        private const string EmailAlias = "eml";
        private readonly double _tempoDeVidaTokenMinutos;
        private readonly string _chaveDeSeguranca;

        public TokenController(double tempoDeVidaTokenMinutos, string chaveDeSeguranca)
        {
            _tempoDeVidaTokenMinutos = tempoDeVidaTokenMinutos;
            _chaveDeSeguranca = chaveDeSeguranca;
        }

        public string GerarToken(string emailUsuario)
        {
            var claims = new List<Claim>
            {
                new Claim(EmailAlias, emailUsuario),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_tempoDeVidaTokenMinutos),
                SigningCredentials = new SigningCredentials(SimetricKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);

        }

        public void ValidarToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var parametrosValidacao = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                IssuerSigningKey = SimetricKey(),
                ClockSkew = new TimeSpan(0),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            tokenHandler.ValidateToken(token, parametrosValidacao, out _);
        }

        private SymmetricSecurityKey SimetricKey()
        {
            var symmetrick = Convert.FromBase64String(_chaveDeSeguranca);
            return new SymmetricSecurityKey(symmetrick);
        }

    }
}
