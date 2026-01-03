namespace Restaurant.Application.DTOs;

public class RestaurantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
}
