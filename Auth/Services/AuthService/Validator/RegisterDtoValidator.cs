using Auth.Services.AuthService.DTOs;
using FluentValidation;

namespace Auth.Services.AuthService.Validator
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator() 
        {
            RuleFor(dto => dto.FullName)
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(dto => dto.BirthDate)
                .LessThan(new DateTime(DateTime.Now.Year - 4))
                .GreaterThan(new DateTime(DateTime.Now.Year - 100));

            RuleFor(dto => dto.Phone)
                .Matches($"^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$");

            RuleFor(dto => dto.Email)
                .EmailAddress();

            RuleFor(dto => dto.Password)
                .MinimumLength(8)
                .MaximumLength(32);
        }
    }
}