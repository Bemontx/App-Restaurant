using MediatR;
using Restaurant.Application.DTOs.Orders;

namespace Restaurant.Application.Features.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDto?>;
