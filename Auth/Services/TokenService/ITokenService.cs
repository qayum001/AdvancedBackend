using Auth.Data.EfClasses;
using Auth.Services.TokenService.DTOs;
using Auth.Services.UserService.DTOs;

namespace Auth.Services.TokenService
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateAccessToken(User user);
        Task<TokenResponse> Refresh(User user, string refreshToken);
        Task<string> GenerateRefreshToken();
        Task<Guid> GetUserIdByToken(string token);
    }
}