using Auth.Data.Additional;
using Auth.Services.AuthService.DTOs;
using Auth.Services.TokenService.DTOs;

namespace Auth.Services.AuthService
{
    public interface IAuthService
    {
        Task<Response> Register(RegisterDto registerDto);
        Task<AuthenticateResponse> Login(LoginCredentials loginCredentials);
        Task<Response> Logout(string token);
        Task<TokenResponse> Refresh(string accessToken, string refreshToken);
    }
}