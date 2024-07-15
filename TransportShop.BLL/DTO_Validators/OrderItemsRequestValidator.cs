using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.BLL.DTO;

namespace TransportShop.BLL.DTO_Validators
{
    internal class OrderItemsRequestValidator : AbstractValidator<OrderItemsRequest>
    {
        public OrderItemsRequestValidator()
        {
            RuleFor(item => item.OrderId)
                .GreaterThan(0)
                .WithMessage("OrderId must be greater than 0");

        }
    }
}
