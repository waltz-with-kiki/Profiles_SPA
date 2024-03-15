using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using try2.Domain.Entities;
using try2.Services.Interfaces;

namespace try2.Services
{
    public class JwtService : IJwtService
    {

        public JwtService(IConfiguration configuration)
        {
            _options = configuration.GetSection("JwtOptions").Get<JwtOptions>();
        }

        

        private readonly JwtOptions _options;
        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[] {new Claim("userId", user.Id.ToString())};

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpitesHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
