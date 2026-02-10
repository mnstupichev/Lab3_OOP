using Lab3.Menu;

namespace Lab3.Order;
    
public class Order
{
    public List<IMenuItem> Items;
    public string? Address;
    public OrderStage _stage { get; private set; }
    public bool Paid { get; }

    public Order(string address, bool paid, List<IMenuItem> items)
    {
        Items = items;
        _stage = OrderStage.Created;
        Paid = false;
    }

    public void ChangeStage(OrderStage stage)
    {
        _stage =  stage;
    }
}

