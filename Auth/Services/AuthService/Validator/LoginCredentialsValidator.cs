using Auth.Services.AuthService.DTOs;
using FluentValidation;

namespace Auth.Services.AuthService.Validator
{
    public class LoginCredentialsValidator : AbstractValidator<LoginCredentials>
    {
        public LoginCredentialsValidator() 
        {
            RuleFor(dto => dto.Email)
                .EmailAddress();

            RuleFor(dto => dto.Password)
                .MinimumLength(8)
                .MaximumLength(32);
        }
    }
}