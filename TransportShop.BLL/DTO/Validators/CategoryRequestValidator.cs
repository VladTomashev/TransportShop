using FluentValidation;
using TransportShop.BLL.DTO.Request;

namespace TransportShop.BLL.DTO.Validators
{
    internal class CategoryRequestValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryRequestValidator()
        {
            RuleFor(category => category.CategoryName)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage("Categoryname must contain more than 3 characters");

            RuleFor(category => category.CategoryName)
                .Matches(@"^[A-Za-z0-9_]*$")
                .WithMessage("Categoryname must contain only letters, numbers or underline");
        }
    }
}
