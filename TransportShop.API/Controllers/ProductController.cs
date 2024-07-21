using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportShop.BLL.DTO.Request;
using TransportShop.DAL.Enums;
using TransportShop.DAL.Interfaces;

namespace TransportShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest request, CancellationToken cancellationToken)
        {
            await productService.Add(request, cancellationToken);
            return Ok();
        }

        [HttpDelete("{productId}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> DeleteProductById(int productId, CancellationToken cancellationToken)
        {
            await productService.Delete(productId, cancellationToken);
            return Ok();
        }

        [HttpGet("{orderId}")]
        [Authorize(Roles = nameof(Role.Manager) + "," + nameof(Role.Admin))]
        public async Task<IActionResult> GetOrderById(int orderId, CancellationToken cancellationToken)
        {
            var product = await productService.GetByIdA(orderId, cancellationToken);
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductRequest request, CancellationToken cancellationToken)
        {
            await productService.Update(productService.GetByName(request.Name).Id, request, cancellationToken);
            return Ok();
        }
    }
}

