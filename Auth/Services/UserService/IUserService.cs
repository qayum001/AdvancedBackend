using Auth.Services.AuthService.DTOs;
using Auth.Services.UserService.DTOs;

namespace Auth.Services.UserService
{
    public interface IUserService
    {
        Task<UserResponse> GetUserResponseByCredentials(LoginCredentials credentials);
        Task<UserResponse> GetUserResponseById(Guid id);
        Task<UserResponse> GetUserResponseByToken(string token);
        Task<UserDto> GetUserDtoById(Guid id);
        Task<UserDto> GetUserDtoByToken(string token);
    }
}