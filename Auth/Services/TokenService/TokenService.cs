using Auth.Data;
using Auth.Data.Additional;
using Auth.Data.EfClasses;
using Auth.Data.Enums;
using Auth.Services.TokenService.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Task.FromResult(Convert.ToBase64String(randomNumber));
        }

        public async Task<TokenResponse> Refresh(User user, string refreshToken)
        {
            if (user.RefreshToken != refreshToken ||
                user.ExpiriesDate < DateTime.Now) 
            {
                var res = new TokenResponse(Status.Fail, "Refresh token is not valid");
                return res;
            }

            var result = await GenerateAccessToken(user);

            return result;
        }

        public async Task<TokenResponse> GenerateAccessToken(User user)
        {
            var claimsIdentity = await GetClaimsIdentity(user);

            var now = DateTime.Now;
            var lifeTime = int.Parse(_configuration["Jwt:LifeTime"]);
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(lifeTime)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = await GenerateRefreshToken();
            var refreshTokenLifeTime = int.Parse(_configuration["Jwt:RefreshTokenLifeTime"]);

            return new TokenResponse(Status.Success, "Access token created", encodedToken, refreshToken, refreshTokenLifeTime);
        }

        public Task<Guid> GetUserIdByToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var readToken = (JwtSecurityToken) jsonToken;

            var res = readToken.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;

            return Task.FromResult(Guid.Parse(res));
        }

        private static Task<ClaimsIdentity> GetClaimsIdentity(User user) 
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var claimsIdetity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return Task.FromResult(claimsIdetity);
        }
    }
}