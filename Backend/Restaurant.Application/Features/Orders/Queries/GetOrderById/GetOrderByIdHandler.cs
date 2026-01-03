using MediatR;
using Restaurant.Application.DTOs.Orders;
using Restaurant.Application.Interfaces.Persistence;

namespace Restaurant.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler
    : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto?> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            return null;

        return new OrderDto
        {
            Id = order.Id,
            TableNumber = order.TableNumber,
            Status = order.Status.ToString(),
            Total = order.GetTotal(),
            Items = order.Items.Select(item => new OrderItemDto
            {
                DishId = item.DishId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Total = item.GetTotal()
            }).ToList()
        };
    }
}
