using Restaurant.Application.DTOs;
using Restaurant.Application.Interfaces;
using RestaurantEntity = Restaurant.Domain.Entities.Restaurant;
using Restaurant.Application.Interfaces.Persistence;

namespace Restaurant.Application.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _repository;

    public RestaurantService(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
    {
        var restaurants = await _repository.GetAllAsync();

        return restaurants.Select(r => new RestaurantDto
        {
            Id = r.Id,
            Name = r.Name,
            Address = r.Address
        });
    }

    public async Task CreateAsync(CreateRestaurantDto dto)
    {
        var restaurant = new  RestaurantEntity
        {
            Id = Guid.NewGuid(),       
            Name = dto.Name,
            Address = dto.Address
        };

        await _repository.AddAsync(restaurant);
    }
}
