using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces.Persistence;
using RestaurantEntity = Restaurant.Domain.Entities.Restaurant;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantDbContext _context;

    public RestaurantRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RestaurantEntity>> GetAllAsync()
    {
        return await _context.Restaurants.ToListAsync();
    }

    public async Task AddAsync(RestaurantEntity restaurant)
    {
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
    }
}
