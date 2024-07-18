using FluentValidation;
using TransportShop.BLL.DTO.Request;

namespace TransportShop.BLL.DTO.Validators
{
    internal class OrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor(order => order.Principal)
                .NotNull()
                .WithMessage("User is not authenticated.");
            RuleFor(order => order.Items)
                .NotNull()
                .WithMessage("There are no items");
        }
    }
}
