
using FluentValidation;
using FluentValidation.Results;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.BLL.Exceptions;
using TransportShop.BLL.Interfaces;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;


namespace TransportShop.BLL.Services
{
    internal class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;
        IValidator<CategoryRequest> validator;
        IProductRepository productRepository;

        public CategoryService(ICategoryRepository repository, IValidator<CategoryRequest> validator, IProductRepository productRepository)
        {
            this.categoryRepository = repository;
            this.validator = validator;
            this.productRepository = productRepository;
        }
        public async Task AddNewCategoryAsync(CategoryRequest category, CancellationToken cancellationToken = default)
        {
            await ValidateCategoryRequestAsync(validator, category, cancellationToken);

            var categories = new Category
            {
                Name = category.CategoryName
            };
                
                await categoryRepository.AddAsync(categories);
        }

        public async Task DeleteCategoryAsync(CategoryRequest category, CancellationToken cancellationToken = default)
        {
            if (await categoryRepository.GetCategoryByNameAsync(category.CategoryName) == null) 
            {
                throw new NotFoundException("Category not found");
            }
            await categoryRepository.DeleteAsync(category.CategoryId, cancellationToken);
        }

        public async Task<List<Category>> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default)
        {
            if (await categoryRepository.GetCategoryByNameAsync(categoryName) == null)
            {
                throw new NotFoundException("Category not found");
            }
            var category = await categoryRepository.GetCategoryByNameAsync(categoryName);
            return category;
        }

        public async Task<CategoryResponse> GetProductsByCategory(CategoryRequest category, CancellationToken cancellationToken = default)
        {
            await ValidateCategoryRequestAsync(validator, category, cancellationToken);
            var products = await productRepository.GetProductByCategoryAsync(category.CategoryName);
            return new CategoryResponse
            {
                ProductsInCategory = products
            };

        }

        private async Task ValidateCategoryRequestAsync(IValidator<CategoryRequest> validator, CategoryRequest request, CancellationToken cancellationToken)
        {
            ValidationResult result = await validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new BadRequestException(errors);
            }
        }
    }
}
