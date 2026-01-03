using RestaurantEntity = Restaurant.Domain.Entities.Restaurant;

namespace Restaurant.Application.Interfaces.Persistence;

public interface IRestaurantRepository
{
    Task<IEnumerable<RestaurantEntity>> GetAllAsync();
    Task AddAsync(RestaurantEntity restaurant);
}
