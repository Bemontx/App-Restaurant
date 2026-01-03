using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantDbContext _context;

    public OrderRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
}
