using Auth.Data.Additional;
using Auth.Data.EfClasses;
using Auth.Data.Enums;

namespace Auth.Services.UserService.DTOs
{
    public class UserResponse : Response
    {
        public User? User { get; private set; }

        public UserResponse(User user, Status status, string message) : base(status, message)
        {
            User = user;
        }

        public UserResponse(Status status, string message) : base(status, message)
        {
            User = null;
        }
    }
}