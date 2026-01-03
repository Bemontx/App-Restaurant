using MediatR;

namespace Restaurant.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(int TableNumber) : IRequest<Guid>;
