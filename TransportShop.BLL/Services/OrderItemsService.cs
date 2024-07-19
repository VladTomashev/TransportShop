using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.BLL.Exceptions;
using TransportShop.BLL.Interfaces;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.BLL.Services
{
    internal class OrderItemsService : IOrderItemsService
    {
        IOrderRepository orderRepository;
        IOrderItemsRepository orderItemsRepository;
        IProductRepository productRepository;
        IValidator<OrderItemsRequest> validator;

        public OrderItemsService(IOrderRepository orderRepository, IOrderItemsRepository orderItemsRepository, IValidator<OrderItemsRequest> validator)
        {
            this.orderRepository = orderRepository;
            this.orderItemsRepository = orderItemsRepository;
            this.validator = validator;
        }

        public async Task AddOrderItem(OrderItemsRequest order, CancellationToken cancellationToken = default)
        {
            await ValidateOrderItemsRequestAsync(validator, order, cancellationToken);

            Product product = await productRepository.GetByIdAsync(order.ProductId, cancellationToken);

            if (product == null) {
                throw new NotFoundException("Product not found");
            }

            Order userOrder = await orderRepository.GetByIdAsync(order.OrderId, cancellationToken);
            if (userOrder == null)
            {
                throw new NotFoundException("Order not found");
            }

            var orderItem = new OrderItem
            {
                IdProduct = order.ProductId,
                IdOrders = order.OrderId,
                Count = order.ProductCount,
               
            };

            await orderItemsRepository.AddAsync(orderItem, cancellationToken);

        }
        public async Task DeleteOrderItem(int id, CancellationToken cancellationToken = default) {
            OrderItem orderItem = await orderItemsRepository.GetByIdAsync(id, cancellationToken);
            if (orderItem == null)
            {
                throw new NotFoundException("OrderItem not found");
            }
            await orderRepository.DeleteAsync(id);
        }
       
        public async Task<List<OrderItemsResponse>> GetOrderItemsAsync(OrderItemsRequest order, CancellationToken cancellationToken = default) {
            Order userOrder = await orderRepository.GetByIdAsync(order.OrderId, cancellationToken);
            if (userOrder == null)
            {
                throw new NotFoundException("Order not found");
            }
            var orderItems= await orderItemsRepository.GetAllAsync(cancellationToken);

            var orderItemsResponse = new List<OrderItemsResponse>();
            foreach (var orderItem in orderItems)
            {
                orderItemsResponse.Add(new OrderItemsResponse { OrderItem = orderItem });
            }
            return orderItemsResponse;
        }
        private async Task ValidateOrderItemsRequestAsync(IValidator<OrderItemsRequest> validator, OrderItemsRequest request, CancellationToken cancellationToken)
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
