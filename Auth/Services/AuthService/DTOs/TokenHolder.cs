namespace Auth.Services.AuthService.DTOs
{
    public class TokenHolder
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public TokenHolder(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
