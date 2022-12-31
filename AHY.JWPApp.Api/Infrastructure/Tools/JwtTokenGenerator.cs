using AHY.JWTApp.Api.Core.Application.Dto.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AHY.JWTApp.Api.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.KEY));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(dto.Role)) 
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            if(!string.IsNullOrEmpty(dto.Username))
                claims.Add(new Claim("Username", dto.Username));

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.EXPIRE);

            JwtSecurityToken jwtSecurityToken = new
                (
                issuer: JwtTokenDefaults.VALID_ISSUER,
                audience: JwtTokenDefaults.VALID_AUDIENCE,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires:expireDate ,
                signingCredentials: credentials
                );


            JwtSecurityTokenHandler handler = new();
            
            return new TokenResponseDto(handler.WriteToken(jwtSecurityToken),expireDate);
          
        }
    }
}
