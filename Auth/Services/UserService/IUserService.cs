using Auth.Services.AuthService.DTOs;
using Auth.Services.UserService.DTOs;

namespace Auth.Services.UserService
{
    public interface IUserService
    {
        Task<UserResponse> GetUserByCredentials(LoginCredentials credentials);
        Task<UserResponse> GetUserById(Guid id);
        //Edit, Delete
    }
}