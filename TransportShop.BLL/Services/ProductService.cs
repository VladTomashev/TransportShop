using FluentValidation;
using FluentValidation.Results;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.BLL.Interfaces;
using TransportShop.BLL.Exceptions;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.BLL.Services
{
    internal class ProductService : IProductService
    {
        IProductRepository productRepository;
        IValidator<ProductRequest> validator;
        ICategoryRepository categoryRepository;

        public ProductService(IProductRepository repository, IValidator<ProductRequest> validator, ICategoryRepository categoryRepository)
        {
            this.productRepository = repository;
            this.validator = validator;
            this.categoryRepository = categoryRepository;
        }

        public async Task Add(ProductRequest product, CancellationToken cancellationToken = default)
        {
            await ValidateProductRequestAsync(validator, product, cancellationToken);

            List<Category> categories = await categoryRepository.GetCategoryByNameAsync(product.CategoryName, cancellationToken);

            if (categories == null)
            {
                throw new NotFoundException("Category not found");
            }

            var products = new Product
            {
                IdCategory = categories[0].Id,
                Name = product.ProductName,
                Price = product.Price,
                Weight = product.Weight,
                MaxSpeed = product.MaxSpeed,
                FuelConsumption = product.FuelConsumption
            };

            await productRepository.AddAsync(products);
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            if (await productRepository.GetByIdAsync(id) == null)
            {
                throw new NotFoundException("Product not found");
            }
            await productRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task Delete(ProductRequest product, CancellationToken cancellationToken = default)
        {
            var prod = productRepository.GetProductsByNameAsync(product.ProductName, cancellationToken);

            if (await productRepository.GetByIdAsync(prod.Id) == null)
            {
                throw new NotFoundException("Product not found");
            }
            await productRepository.DeleteAsync(prod.Id, cancellationToken);
        }

        public async Task<ProductResponse> GetByID(int productID, CancellationToken cancellationToken = default)
        {
            if (await productRepository.GetByIdAsync(productID) == null)
            {
                throw new NotFoundException("Product not found");
            }
            var product = await productRepository.GetByIdAsync(productID, cancellationToken);

            var products = new ProductResponse
            {
                CategoryName = product.Category.Name,
                Price = product.Price,
                Weight = product.Weight,
                MaxSpeed = product.MaxSpeed,
                FuelConsumption = product.FuelConsumption
            };

            return products;
        }

        public async Task<ProductResponse> GetByName(string name, CancellationToken cancellationToken = default)
        {
            if (await productRepository.GetProductsByNameAsync(name) == null)
            {
                throw new NotFoundException("Product not found");
            }
            var product = await productRepository.GetProductsByNameAsync(name, cancellationToken);

            var products = new ProductResponse
            {
               CategoryName = product[0].Category.Name,
               Price = product[0].Price,
               Weight = product[0].Weight,
               MaxSpeed = product[0].MaxSpeed,
               FuelConsumption = product[0].FuelConsumption
            };

            return products;
        }

        

        public async Task Update(int id, ProductRequest product, CancellationToken cancellationToken = default)
        {
            if (await productRepository.GetByIdAsync(id) == null)
            {
                throw new NotFoundException("Product not found");
            }

            List<Category> categories = await categoryRepository.GetCategoryByNameAsync(product.CategoryName, cancellationToken);

            var products = new Product
            {
                Id = id,
                IdCategory = categories[0].Id,
                Name = product.ProductName,
                Price = product.Price,
                Weight = product.Weight,
                MaxSpeed = product.MaxSpeed,
                FuelConsumption = product.FuelConsumption,
                Category = categories[0]
            };

            await productRepository.UpdateAsync(products, cancellationToken);
        }

        private async Task ValidateProductRequestAsync(IValidator<ProductRequest> validator, ProductRequest request, CancellationToken cancellationToken)
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
