using MediatR;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = new Order(request.TableNumber);

        await _orderRepository.AddAsync(order);

        return order.Id;
    }
}
