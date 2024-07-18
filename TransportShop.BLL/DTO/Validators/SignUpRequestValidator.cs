using FluentValidation;
using TransportShop.BLL.DTO.Request;

namespace TransportShop.BLL.DTO.Validators
{
    public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpRequestValidator()
        {
            RuleFor(r => r.Login)
                .NotEmpty().WithMessage("Login is required")
                .Length(3, 50).WithMessage("The login length must be from 3 to 50 characters")
                .Matches(@"^[A-Za-z0-9_]*$").WithMessage("Login must contain only letters, numbers or underline");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(8, 50).WithMessage("The password length must be from 8 to 50 characters");

            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(3, 50).WithMessage("The name length must be from 3 to 50 characters")
                .Matches(@"^[a-zA-Zа-яА-Я\s]+$").WithMessage("Name must contain only letters and spaces");

            RuleFor(r => r.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Incorrect phone number");

            RuleFor(r => r.Address)
                .NotEmpty().WithMessage("Address is required")
                .Length(3, 50).WithMessage("The address length must be from 3 to 50 characters");

        }
    }
}
