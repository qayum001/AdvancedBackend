using Auth.Data.Additional;
using Auth.Data.Enums;
using Auth.Services.AuthService;
using Auth.Services.AuthService.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) 
        { 
            _authService = authService;
        }

        [HttpPost(nameof(Register))]
        public async Task<ActionResult<Response>> Register([FromBody] RegisterDto registerDto)//add validator to RegisterDto
        {
            if (!ModelState.IsValid) return BadRequest("Not valid credentials");

            var registerResponse = await _authService.Register(registerDto);

            if (registerResponse.Status == Status.Fail) return Forbid(registerResponse.Message);

            return Ok(registerResponse);
        }

        [HttpPost(nameof(Login))]
        public async Task<ActionResult<TokenHolder>> Login([FromBody] LoginCredentials loginCredentials)
        {
            if (!ModelState.IsValid) return BadRequest("Not valid credentials");

            var loginResponse = await _authService.Login(loginCredentials);

            if(loginResponse.Status == Status.Fail) return Unauthorized(loginResponse.Message);

            return Ok(loginResponse.TokenHolder);
        }

        [HttpPost(nameof(Refresh))]
        [Authorize]
        public async Task<ActionResult<TokenHolder>> Refresh([FromBody] string refreshToken)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken == null) return BadRequest("Token is not found");

            var tokenResponse = await _authService.Refresh(accessToken, refreshToken);

            if (tokenResponse.Status == Status.Fail) return BadRequest(tokenResponse.Message);

            return Ok(new TokenHolder(tokenResponse.AccessToken, tokenResponse.RefreshToken));
        }

        [HttpPost(nameof(Logout))]
        [Authorize]
        public async Task<ActionResult<Response>> Logout()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken == null) return BadRequest("Token is not found");

            var response = await _authService.Logout(accessToken);

            if(response.Status == Status.Fail) return BadRequest(response.Message);

            return Ok(response);
        }
    }
}