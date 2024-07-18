using FluentValidation;
using FluentValidation.Results;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.BLL.Interfaces;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.BLL.Services
{
    internal class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        IUserRepository userRepository;
        IValidator<OrderRequest> orderValidator;
        IUserService userService;
        
        public OrderService(IOrderRepository orderRepository, IValidator<OrderRequest> orderValidator, 
            IUserService userService, IUserRepository userRepository)
        {
            this.orderRepository = orderRepository;
            this.orderValidator = orderValidator;
            this.userService = userService;
            this.userRepository = userRepository;
        }

        public async Task CreateOrderAsync(OrderRequest request, CancellationToken cancellationToken = default)
        {
            await ValidateOrderRequestAsync(orderValidator, request, cancellationToken);
            var userId = await userService.GetMyIdByJwtAsync(request.Principal, cancellationToken);
            var user = await userRepository.GetByIdAsync(userId);
            var totalPrice = 0.0;
            foreach (var item in request.Items)
            {
                totalPrice += item.Product.Price * item.Count;
            }

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            else
            {
                var order = new Order
                {
                    IdUser = userId,
                    TotalPrice = totalPrice,
                    User = user,
                    OrderItems = request.Items
                };

                await orderRepository.AddAsync(order);
            }
        }

        public async Task DeleteOrderById(int orderId, CancellationToken cancellationToken = default)
        {
            if (await orderRepository.GetByIdAsync(orderId) == null)
            {
                throw new NotFoundException("Order not found");
            }
            await orderRepository.DeleteAsync(orderId);
        }

        public async Task<OrderResponse> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken = default)
        {
            if (await orderRepository.GetByIdAsync(orderId) == null)
            {
                throw new NotFoundException("Order not found");
            }
            var order = await orderRepository.GetByIdAsync(orderId);
            return new OrderResponse
            {
                Order = order
            };
        }

        public async Task<List<OrderResponse>> GetOrdersByUserAsync(OrderRequest request, CancellationToken cancellationToken = default)
        {
            await ValidateOrderRequestAsync(orderValidator, request, cancellationToken);
            var userId = await userService.GetMyIdByJwtAsync(request.Principal, cancellationToken);
            var orders = await orderRepository.GetOrdersByUserAsync(userId);           
            return new OrdersListResponse
            {
                Orders = orders
            };
        }

        private async Task ValidateOrderRequestAsync(IValidator<OrderRequest> validator, OrderRequest request, CancellationToken cancellationToken)
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
