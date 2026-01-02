using Restaurant.Domain.Common;

namespace Restaurant.Domain.Entities;

public class Dish : BaseEntity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; }
    public Guid CategoryId { get; private set; }

    private Dish() { }

    public Dish(string name, decimal price, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Dish name is required");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        Name = name;
        Price = price;
        CategoryId = categoryId;
        IsAvailable = true;
    }

    public void Disable() => IsAvailable = false;
    public void Enable() => IsAvailable = true;
}
