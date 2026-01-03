namespace Restaurant.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; }
    public Guid DishId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    private OrderItem() { }

    public OrderItem(Guid dishId, int quantity, decimal unitPrice)
    {
        Id = Guid.NewGuid();
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        DishId = dishId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public decimal GetTotal() => Quantity * UnitPrice;
}
