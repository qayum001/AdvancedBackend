using Auth.Data;
using Auth.Data.Enums;
using Auth.Services.AuthService.DTOs;
using Auth.Services.TokenService;
using Auth.Services.UserService.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auth.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(AuthDbContext context,
            ITokenService tokenService,
            IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserDtoById(Guid id)
        {
            var userResponse = await GetUserResponseById(id);

            return _mapper.Map<UserDto>(userResponse.User);
        }

        public async Task<UserDto> GetUserDtoByToken(string token)
        {
            var id = await _tokenService.GetUserIdByToken(token);

            var userResponse = await GetUserResponseById(id);

            return _mapper.Map<UserDto>(userResponse.User);
        }

        public async Task<UserResponse> GetUserResponseByCredentials(LoginCredentials credentials)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(e => e.Email == credentials.Email);

            if (user == null) return new UserResponse(Status.Fail, "User not found");

            if(user.Password != credentials.Password) return new UserResponse(Status.Fail, "Incorrect email or password");

            return new UserResponse(user, Status.Success, "User found");
        }

        public async Task<UserResponse> GetUserResponseById(Guid id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(e => e.Id == id);

            if (user == null) return new UserResponse(Status.Fail, "User not found");

            return new UserResponse(user, Status.Success, "User found");
        }

        public async Task<UserResponse> GetUserResponseByToken(string token)
        {
            var id = await _tokenService.GetUserIdByToken(token);

            return await GetUserResponseById(id);
        }
    }
}