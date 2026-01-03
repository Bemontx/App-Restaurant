namespace Restaurant.Application.DTOs.Orders;

public class OrderDto
{
    public Guid Id { get; set; }
    public int TableNumber { get; set; }
    public string Status { get; set; } = default!;
    public decimal Total { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}
