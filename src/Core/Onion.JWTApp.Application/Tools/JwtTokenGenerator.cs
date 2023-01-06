using Microsoft.IdentityModel.Tokens;
using Onion.JWTApp.Application.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Onion.JWTApp.API.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.KEY));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.EXPIRE);

            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(dto.Role))
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));
            if (!String.IsNullOrWhiteSpace(dto.Username))
                claims.Add(new Claim("Username", dto.Username));

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.VALID_ISSUER, audience: JwtTokenDefaults.VALID_AUDIENCE, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signInCredentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.WriteToken(token);

            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
