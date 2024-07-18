using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportShop.BLL.DTO.Request;
using TransportShop.DAL.Interfaces;

namespace TransportShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.User))]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request, CancellationToken cancellationToken)
        {
            await orderService.CreateOrderAsync(request, cancellationToken);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> DeleteOrderById(int orderId, CancellationToken cancellationToken)
        {
            await orderService.DeleteOrderById(orderId, cancellationToken);
            return Ok();
        }

        [HttpGet("{orderId}")]
        [Authorize(Roles = nameof(Role.Manager) + "," + nameof(Role.Admin))]
        public async Task<IActionResult> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken)
        {
            var order = await orderService.GetOrderByIdAsync(orderId, cancellationToken);
            return Ok(order);
        }

        [HttpPost("user")]
        [Authorize(Roles = nameof(Role.Manager) + "," + nameof(Role.Admin))]
        public async Task<IActionResult> GetOrdersByUser([FromBody] OrderRequest request, CancellationToken cancellationToken)
        {
            var orders = await orderService.GetOrdersByUserAsync(request, cancellationToken);
            return Ok(orders);
        }      
    }
}
