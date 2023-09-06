using Auth.Data.Additional;
using Auth.Data.Enums;

namespace Auth.Services.TokenService.DTOs
{
    public class TokenResponse : Response
    {
        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime RefreshTokenExpiriesDate { get; private set; }
        
        public TokenResponse(Status status,
            string message,
            string accessToken,
            string refreshToken,
            int refreshTokenLifetime)
            : base(status, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            RefreshTokenExpiriesDate = DateTime.Now.AddDays(refreshTokenLifetime);
        }

        public TokenResponse() : base() 
        { 
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
        }

        public TokenResponse(Status status, string message)
            : base(status, message)
        {
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
        }
    }
}