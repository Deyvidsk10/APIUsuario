using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuarioApi.Domain.Interfaces;

namespace UsuarioApi.Infrastructure.Security.Tokens
{
    public class TokenServico : ITokenServico
    {
        public string GerarToken(Guid id, string email)
        {
            var manipuladorToken = new JwtSecurityTokenHandler();
            var chaveCriptografada = Encoding.ASCII.GetBytes("SuaChaveSuperSecretaComPeloMenos32Caracteres");

            var descricaoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email)
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chaveCriptografada),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manipuladorToken.CreateToken(descricaoToken);
            return manipuladorToken.WriteToken(token);
        }
    }
}
