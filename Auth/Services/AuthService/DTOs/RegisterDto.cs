using Auth.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Auth.Services.AuthService.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}