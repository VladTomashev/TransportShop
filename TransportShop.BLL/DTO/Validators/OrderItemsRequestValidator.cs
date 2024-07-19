using FluentValidation;
using TransportShop.DAL.Interfaces;
using TransportShop.BLL.DTO.Request;

namespace TransportShop.BLL.DTO.Validators
{
    internal class OrderItemsRequestValidator : AbstractValidator<OrderItemsRequest>
    {
        public OrderItemsRequestValidator()
        {
     

            RuleFor(item => item.OrderId)
                .GreaterThan(0)
                .WithMessage("OrderId must be greater than 0");
            RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId должен быть больше 0, если он указан.");
        }
    }
}
