using Restaurant.Application.DTOs;

namespace Restaurant.Application.Interfaces;

public interface IRestaurantService
{
    Task<IEnumerable<RestaurantDto>> GetAllAsync();
    Task CreateAsync(CreateRestaurantDto dto);
}
