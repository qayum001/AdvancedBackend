using Auth.Data.EfClasses;
using Auth.Data.Enums;
using AutoMapper;

namespace Auth.Services.UserService.DTOs
{
    public class UserDto
    {
        public string FullName { get; }
        public string Email { get; }
        public DateTime BirthDate { get; }
        public Gender Gender { get; }

        private class UserDtoProfile : Profile
        {
            private UserDtoProfile()
            {
                CreateMap<User, UserDto>();
            }
        }
    }
}