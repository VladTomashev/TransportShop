using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using TransportShop.BLL.DTO;


namespace TransportShop.BLL.DTO_Validators
{
    internal class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(x => x.CategoryId)
            .GreaterThan(0).When(x => x.CategoryId.HasValue)
            .WithMessage("CategoryId должен быть больше 0, если он указан.");

            RuleFor(x => x.ProductName)
            .Must(name => Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
            .WithMessage("ProductName должен содержать только буквы и цифры.");
        }
    }
}
