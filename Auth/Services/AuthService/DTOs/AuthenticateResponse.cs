using Auth.Data.Additional;
using Auth.Data.Enums;

namespace Auth.Services.AuthService.DTOs
{
    public class AuthenticateResponse : Response
    {
        public TokenHolder TokenHolder { get; private set; }

        public AuthenticateResponse(string accessToken,
            string refreshToken,
            Status status,
            string message) : base(status, message)
        {
            TokenHolder = new TokenHolder(accessToken, refreshToken);
        }

        public AuthenticateResponse(Status status, string message) : base (status, message)
        {
            TokenHolder = new TokenHolder(string.Empty, string.Empty);
        }
    }
}