using Auth.Data;
using Auth.Data.Additional;
using Auth.Data.EfClasses;
using Auth.Data.Enums;
using Auth.Services.AuthService.DTOs;
using Auth.Services.TokenService;
using Auth.Services.TokenService.DTOs;
using Auth.Services.UserService;

namespace Auth.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(AuthDbContext context, IUserService userService, ITokenService tokenSerive)
        {
            _context = context;
            _userService = userService;
            _tokenService = tokenSerive;
        }

        public async Task<AuthenticateResponse> Login(LoginCredentials loginCredentials)
        {
            var userResponse = await _userService.GetUserByCredentials(loginCredentials);

            if (userResponse.User == null) return new AuthenticateResponse(Status.Fail, userResponse.Message);

            var user = userResponse.User;

            var tokenResponse = await _tokenService.GenerateAccessToken(userResponse.User);

            await user.UpdateRefreshToken(tokenResponse.RefreshToken);
            await user.UpdateExpiryingsDate(tokenResponse.RefreshTokenExpiriesDate);

            await _context.SaveChangesAsync();

            return new AuthenticateResponse(tokenResponse.AccessToken, tokenResponse.RefreshToken, Status.Success, "Loged in");
        }

        public async Task<TokenResponse> Refresh(string accessToken, string refreshToken)
        {
            var userId = await _tokenService.GetUserIdByToken(accessToken);
            
            var userResponse = await _userService.GetUserById(userId);

            if (userResponse.Status == Status.Fail || userResponse.User == null)
                return new TokenResponse(Status.Fail, userResponse.Message);

            var user = userResponse.User;

            var res = await _tokenService.Refresh(user, refreshToken);

            await user.UpdateRefreshToken(res.RefreshToken);
            await user.UpdateExpiryingsDate(res.RefreshTokenExpiriesDate);
            
            await _context.SaveChangesAsync();

            return res;
        }

        public async Task<Response> Logout(string token)
        {
            var id = await _tokenService.GetUserIdByToken(token);

            var userResponse = await _userService.GetUserById(id);

            if (userResponse.User == null) return new Response(Status.Fail, userResponse.Message);

            await userResponse.User.UpdateExpiryingsDate(DateTime.Now);

            await _context.SaveChangesAsync();

            return new Response(Status.Success, "Logged out");
        }

        public async Task<Response> Register(RegisterDto registerDto)
        {
            var userResponse = await _userService.GetUserByCredentials(new LoginCredentials(registerDto.Email, registerDto.Password));

            if (userResponse.Status == Status.Success) return new Response(Status.Fail, "This email is not available");

            var user = new Customer(registerDto.FullName,registerDto.BirthDate,
                registerDto.Gender,registerDto.Phone,registerDto.Email,
                registerDto.Address,registerDto.Password);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return new Response(Status.Success, "User created");
        }
    }
}