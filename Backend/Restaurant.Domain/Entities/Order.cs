using Restaurant.Domain.Common;
using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Entities;

public class Order : BaseEntity
{
    public int TableNumber { get; private set; }
    public OrderStatus Status { get; private set; }
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { }

    public Order(int tableNumber)
    {
        if (tableNumber <= 0)
            throw new ArgumentException("Invalid table number");

        TableNumber = tableNumber;
        Status = OrderStatus.Open;
    }

    public void AddItem(Guid dishId, int quantity, decimal price)
    {
        if (Status != OrderStatus.Open)
            throw new InvalidOperationException("Cannot modify a closed order");

        _items.Add(new OrderItem(dishId, quantity, price));
    }

    public decimal GetTotal() => _items.Sum(i => i.GetTotal());

    public void Close()
    {
        if (!_items.Any())
            throw new InvalidOperationException("Cannot close an empty order");

        Status = OrderStatus.Closed;
    }
}
