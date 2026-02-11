using Lab3.Menu;

namespace Lab3.Orders;
    
public class Order
{
    public List<IMenuItem> Items;
    public string? Address;
    public OrderStage Stage { get; private set; }
    public bool IsPaid { get; private set; }

    public Order(string address, bool isPaid, List<IMenuItem> items)
    {
        Address = address;
        Items = items;
        Stage = OrderStage.Created;
        IsPaid = isPaid;
    }

    public void ChangeStage(OrderStage stage)
    {
        Stage =  stage;
    }
}

