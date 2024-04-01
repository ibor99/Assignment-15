using Assignment_15;

public class OrderRepository
{
    private List<Order> _orders = new List<Order>();

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public void RemoveOrder(Order order)
    {
        _orders.Remove(order);
    }

    public Order GetOrder(string name)
    {
        return _orders.FirstOrDefault(o => o.Name == name);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _orders;
    }
}
