using FluentValidation;
using TransportShop.BLL.DTO.Request;

namespace TransportShop.BLL.DTO.Validators
{
    internal class OrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor(order => order.UserName)
                    .NotEmpty()
                    .MinimumLength(4)
                    .WithMessage("Username must contain more than 3 characters");

            RuleFor(order => order.UserName)
                    .Matches(@"^[A-Za-z0-9_]*$")
                    .WithMessage("Username must contain only letters, numbers or underline");

            RuleFor(order => order.Items)
                .NotNull()
                .WithMessage("There are no items");
        }
    }
}
