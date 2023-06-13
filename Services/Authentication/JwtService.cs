using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using P2P.Domain.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Authentication
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _options;
        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        private string Generate(Claim[] claims)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(8),
                signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenValue;
        }
    }
}
