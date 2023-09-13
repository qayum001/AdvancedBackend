using Auth.Data;
using Auth.Data.Additional;
using Auth.Data.EfClasses;
using Auth.Data.Enums;
using Auth.Services.AccauntService.DTOs;
using Auth.Services.TokenService;
using Auth.Services.UserService;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Services.AccauntService
{
    public class AccountService : IAccountService
    {
        private readonly AuthDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AccountService(AuthDbContext context,
            ITokenService tokenService,
            IUserService userService)
        {
            _context = context;
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<Response> Delete(string token)
        {
            var id = await _tokenService.GetUserIdByToken(token);
            
            var userResponse = await _userService.GetUserResponseById(id);

            if (userResponse.User == null) { return userResponse; }

            _context.Users.Remove(userResponse.User);

            await _context.SaveChangesAsync();

            return new Response(Status.Success, "Account Deleted");
        }

        public async Task<Response> Update(AccountUpdateDto accountUpdateDto, string token)
        {
            var id = await _tokenService.GetUserIdByToken(token);

            var userResponse = await _userService.GetUserResponseById(id);

            if (userResponse.User == null) { return userResponse; }

            var user = userResponse.User;

            //add Update method to User?
            await user.ReName(accountUpdateDto.FullName);
            await user.UpdeteBirthDate(accountUpdateDto.BirthDate);
            await user.UpdateGender(accountUpdateDto.Gender);

            if (user.Role == "Customer" && !accountUpdateDto.Address.IsNullOrEmpty())
            {
                var customer = (Customer)user;
                await customer.UpdateAddress(accountUpdateDto.Address);
            }

            await _context.SaveChangesAsync();

            return new Response(Status.Success, "Account updated");
        }
    }
}
