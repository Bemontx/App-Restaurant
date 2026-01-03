using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Persistence;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
}
 