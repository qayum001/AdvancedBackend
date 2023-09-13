using Auth.Data.Additional;
using Auth.Data.EfClasses;
using Auth.Services.AccauntService;
using Auth.Services.AccauntService.DTOs;
using Auth.Services.UserService;
using Auth.Services.UserService.DTOs;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService,
            IUserService userService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet(nameof(GetUserProfile))]
        [Authorize(Roles = nameof(Customer))]
        public async Task<ActionResult<UserDto>> GetUserProfile()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken == null) return BadRequest("Access token is not found");

            var dto = await _userService.GetUserDtoByToken(accessToken);

            return dto;
        }

        [HttpPut(nameof(UpdateProfile))]
        [Authorize(Roles = nameof(Customer))]
        public async Task<ActionResult<Response>> UpdateProfile([FromBody] AccountUpdateDto updateDto)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken == null) return BadRequest("Access token is not found");

            var response = _accountService.Update(updateDto, accessToken);

            return Ok(response);
        }

        [HttpPut(nameof(DeleteAccount))]
        [Authorize(Roles = nameof(Customer))]
        public async Task<ActionResult<Response>> DeleteAccount()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken == null) return BadRequest("Access token is not found");

            var response = _accountService.Delete(accessToken);

            return Ok(response);
        }
    }
}