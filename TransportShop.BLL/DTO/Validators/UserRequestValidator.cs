using FluentValidation;
using TransportShop.BLL.DTO.Request;

namespace TransportShop.BLL.DTO.Validators
{
    internal class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(user => user.UserName)
                    .NotEmpty()
                    .MinimumLength(4)
                    .WithMessage("Username must contain more than 3 characters");

            RuleFor(user => user.UserName)
                    .Matches(@"^[A-Za-z0-9_]*$")
                    .WithMessage("Username must contain only letters, numbers or underline");

            RuleFor(user => user.Password)
                    .NotEmpty()
                    .MinimumLength(16)
                    .WithMessage("Password must contain more than 16 symbols");
        }
    }
}
