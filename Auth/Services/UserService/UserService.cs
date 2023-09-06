using Auth.Data;
using Auth.Data.Enums;
using Auth.Services.AuthService.DTOs;
using Auth.Services.UserService.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Auth.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _context;

        public UserService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponse> GetUserByCredentials(LoginCredentials credentials)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(e => e.Email == credentials.Email);

            if (user == null) return new UserResponse(Status.Fail, "User not found");

            if(user.Password != credentials.Password) return new UserResponse(Status.Fail, "Incorrect email or password");

            return new UserResponse(user, Status.Success, "User found");
        }

        public async Task<UserResponse> GetUserById(Guid id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(e => e.Id == id);

            if (user == null) return new UserResponse(Status.Fail, "User not found");

            return new UserResponse(user, Status.Success, "User found");
        }
    }
}