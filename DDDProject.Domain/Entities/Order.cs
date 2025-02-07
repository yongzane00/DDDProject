namespace DDDProject.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public decimal TotalAmount { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { } // Required for EF Core

    public Order(string customerName)
    {
        Id = Guid.NewGuid();
        CustomerName = customerName;
    }

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        TotalAmount = _items.Sum(i => i.Price * i.Quantity);
    }
}
